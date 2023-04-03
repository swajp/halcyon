using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Halcyon
{
    public partial class LoginForm : Form
    {
        UIActions actions;
        public LoginForm()
        {
            InitializeComponent();
            actions = new UIActions();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            actions.CloseApp();
        }

        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            actions.MinimizeApp(this);
        }

        private void panelMoving_MouseDown(object sender, MouseEventArgs e)
        {
            actions.MoveApp(sender, e, this);
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            //SqlRepository.CreateUser(textBoxUsername.Text, textBoxPassword.Text);
            var user = SqlRepository.GetUser(textBoxUsername.Text.Trim());

            if (user != null)
            {
                if (user.VerifyPassword(textBoxPassword.Text))
                {
                    if (user.Role == (int)SqlRepository.Roles.ADMIN)
                    {
                        this.Hide();
                        AdminForm adminForm = new AdminForm(user);
                        adminForm.Show();
                    }
                    else if (user.Role == (int)SqlRepository.Roles.USER)
                    {
                        this.Hide();
                        AdminForm adminForm = new AdminForm(user);
                        adminForm.Show();
                    }
                 
                }
                return;
            }
            MessageBox.Show("Username or password incorrect.");
         
        }
    }
}
