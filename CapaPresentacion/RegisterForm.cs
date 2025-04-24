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
using UserCredentials;

namespace CapaPresentacion
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            if(UserSession.Instance.Rol == "admin")
            {
                IsAdmin.Visible = true;
            }
        }
        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            string name = NameInput.Text;
            string email = EmailInput.Text;
            string password = PasswordInput.Text;
            string rol = IsAdmin.Checked ? "admin" : "user";
            BussinessLogic logic = new BussinessLogic();
            bool success = logic.RegisterUser(name, email, password, rol);

            if (success)
            {
                MessageBox.Show("Usuario registrado correctamente!");
                NameInput.Clear();
                EmailInput.Clear();
                PasswordInput.Clear();
            }
            else
            {
                MessageBox.Show("Error. Verifique los campos");
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(UserCredentials.UserSession.Instance.id);

        }
    }
}
