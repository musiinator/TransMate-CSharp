using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransportModel.domain;
using TransportPersistance.repository;
using TransportPersistance.repository.Interfaces;
using TransportService;

namespace TransportClientFX
{
    public partial class LoginForm : Form
    {
        private TransportClientController controller;
        public LoginForm(TransportClientController controller)
        {
            InitializeComponent();
            this.controller = controller;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameText.Text;
            string password = passwordText.Text;
            try
            {
                controller.login(username, password);
                User loggedUser = controller.findUserByUsername(username);
                MessageBox.Show("Login succeded");
                MenuForm menuForm = new MenuForm(controller, loggedUser);
                this.Hide();
                menuForm.Text = "Main menu";
                menuForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Login Error " + ex.Message/*+ex.StackTrace*/, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
        }
    }
}