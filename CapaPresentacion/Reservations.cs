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
using Entity;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using UserCredentials;

namespace CapaPresentacion
{
    public partial class Reservations : Form
    {
        public Reservations()
        {
            InitializeComponent();
            ReservationGrid.ClearSelection();

            if (UserSession.Instance.Rol == "admin")
            {
                DoneBtn.Visible = true;
                QuequeBtn.Visible = true;
            }
            if (UserCredentials.UserSession.Instance.Session)
            {
                BussinessLogic logic = new BussinessLogic();
                List<BookingEntity> data = logic.GetReservations();
                foreach (var item in data)
                {
                    ReservationGrid.Rows.Add(item.userName, item.service, item.date, item.state, item.id);
                }
            }
            else
            {
                MessageBox.Show("Debes de registrado para cargar las reservas");
            }
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
        private void RefreshGrid()
        {
            ReservationGrid.Rows.Clear();
            BussinessLogic logic = new BussinessLogic();
            List<BookingEntity> data = logic.GetReservations();
            foreach (var item in data)
            {
                Console.WriteLine(item.service);
                ReservationGrid.Rows.Add(item.userName, item.service, item.date, item.state, item.id);
            }
            ReservationGrid.ClearSelection();
        }
        private void ConfirmBtn_Click_1(object sender, EventArgs e)
        {
            DateTime date = Date.Value;
            string hour = HourInput.Text;
            string fullDate = date.ToString("yyyy-MM-dd") + " " + hour + ":00:00";
            string service = ServicesInput.SelectedValue.ToString();

            BussinessLogic logic = new BussinessLogic();
            if (logic.CreateReservation(fullDate, int.Parse(service)))
            {
                MessageBox.Show("Reserva creada correctamente");
            }
            else
            {
                MessageBox.Show("Error al crear la reserva");
            }
            Console.WriteLine(service);
        }

        private void DeleteBtn_Click_1(object sender, EventArgs e)
        {
            int selectedRow = ReservationGrid.CurrentCell.RowIndex;
            string id = ReservationGrid.Rows[selectedRow].Cells[4].Value.ToString();
            BussinessLogic bussinessLogic = new BussinessLogic();
            if (bussinessLogic.DeleteRervation(id))
            {
                MessageBox.Show("Reservation deleted successfully");
                ReservationGrid.Rows.RemoveAt(selectedRow);
            }
            else
            {
                MessageBox.Show("Error deleting reservation");
            }
        }

        private void Reservations_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'servicesDataSet.services' table. You can move, or remove it, as needed.
            this.servicesTableAdapter.Fill(this.servicesDataSet.services);

        }

        private void DoneBtn_Click_1(object sender, EventArgs e)
        {

            int selectedRow = ReservationGrid.CurrentCell.RowIndex;
            string id = ReservationGrid.Rows[selectedRow].Cells[4].Value.ToString();

            BussinessLogic bussinessLogic = new BussinessLogic();


            try
            {
                bussinessLogic.SetServicesState(id, "completo");
                MessageBox.Show("Reservacion marcada como completada");
                RefreshGrid();  

            }
              catch
            {
                MessageBox.Show("Error al marcar como completada la reserva");
            }
        }

        private void QuequeBtn_Click(object sender, EventArgs e)
        {
            int selectedRow = ReservationGrid.CurrentCell.RowIndex;
            string id = ReservationGrid.Rows[selectedRow].Cells[4].Value.ToString();
            BussinessLogic bussinessLogic = new BussinessLogic();
            try
            {
                bussinessLogic.SetServicesState(id, "En espera");
                MessageBox.Show("Reservacion marcada como en espera");
                RefreshGrid();
            }
            catch
            {
                MessageBox.Show("Error al marcar como en espera la reserva");
            }
        }



        private void GeneratePDF_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveFileDialog.Title = "Save PDF File";
                saveFileDialog.FileName = "ExportedData.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportDataGridViewToPdf(ReservationGrid, saveFileDialog.FileName);
                }
            }
        }

    }
}
