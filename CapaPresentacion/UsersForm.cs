using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;

namespace CapaPresentacion
{
    public partial class UsersForm : Form
    {
        public UsersForm()
        {
            InitializeComponent();
        }
        private void ExportDataGridViewToPdf(DataGridView dataGridView, string filename)
        {
            var document = new Document();
            var section = document.AddSection();

            var table = section.AddTable();
            table.Borders.Width = 0.75;

            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                table.AddColumn(Unit.FromCentimeter(5));
            }

            var headerRow = table.AddRow();
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                headerRow.Cells[i].AddParagraph(dataGridView.Columns[i].HeaderText);
                headerRow.Cells[i].Format.Font.Bold = true;
            }

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.IsNewRow) continue;

                var pdfRow = table.AddRow();
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    pdfRow.Cells[i].AddParagraph(row.Cells[i].Value?.ToString() ?? string.Empty);
                }
            }

            var renderer = new PdfDocumentRenderer(true);
            renderer.Document = document;
            renderer.RenderDocument();
            renderer.PdfDocument.Save(filename);

            MessageBox.Show("PDF Creado correctamente!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'reservationsDataSet.users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.reservationsDataSet.users);

        }

        private void GeneratePDFBtn_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveFileDialog.Title = "Save PDF File";
                saveFileDialog.FileName = "ExportedData.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportDataGridViewToPdf(UsersGrid, saveFileDialog.FileName);
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            int selectedRow = UsersGrid.CurrentCell.RowIndex;
            string id = UsersGrid.Rows[selectedRow].Cells[0].Value.ToString();

            BussinessLogic logic = new BussinessLogic();
            try
            {
                logic.DeleteUser(id);
                UsersGrid.Rows.RemoveAt(selectedRow);
                MessageBox.Show("Usuario eliminado correctamente");

            }
            catch
            {
                MessageBox.Show("Error al eliminar el usuario");
            }
            finally
            {
                UsersGrid.ClearSelection();
            }
        }
    }
   }


