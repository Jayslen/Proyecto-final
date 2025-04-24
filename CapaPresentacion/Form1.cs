using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserCredentials;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loadForms(new LoginForm());
        }

        public void loadForms(object form)
        {
            if (this.MainPanel.Controls.Count > 0)
                this.MainPanel.Controls.RemoveAt(0);
            Form f = form as Form;
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            this.MainPanel.Controls.Add(f);
            this.MainPanel.Tag = f;
            f.Show();
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            loadForms(new RegisterForm());

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(UserCredentials.UserSession.Instance.id);
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            loadForms(new LoginForm());
        }

        private void reservationBtn_Click(object sender, EventArgs e)
        {
            if (UserSession.Instance.Session)
            {
                loadForms(new Reservations());
            }
            else
            {
                MessageBox.Show("Debes de iniciar sesión para cargar las reservas");
            }
        }
        public void ShowUserButton()
        {
            usersBtn.Visible = true;
        }

        private void usersBtn_Click(object sender, EventArgs e)
        {
            if(UserSession.Instance.Rol == "admin")
            {
                loadForms(new UsersForm());
            } else {
                MessageBox.Show("No tienes permisos para acceder a esta sección");
            }
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            if(UserSession.Instance.Session)
            {
                UserSession.Instance.ClearSession();
                MessageBox.Show("Session cerrada");
                loadForms(new LoginForm());
            } 
        }
    }
}
