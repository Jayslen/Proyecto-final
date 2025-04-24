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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            BussinessLogic logic = new BussinessLogic();
            string name = UserInput.Text;
            string password = PasswordInput.Text;
            bool loginSuscess = logic.LoginUser(name, password);
            Console.WriteLine(loginSuscess);
            if (logic.LoginUser(name, password))
            {
                MessageBox.Show("Inicio de session exitoso");
                UserInput.Clear();
                PasswordInput.Clear();
            }
            else
            {
                MessageBox.Show("Verifique las credenciales");
            }
        }
    }
}
