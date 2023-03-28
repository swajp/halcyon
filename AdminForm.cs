using Halcyon.src;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Halcyon
{
    public partial class AdminForm : Form
    { 
        UIActions actions;
        private List<User> users;

        bool show = false;

        static class SelectedEdit
        {
            public const string User = "Users";
            public const string Employee = "Employees";
            public const string Contract = "Contracts";
        }

        string selectedEdit;
        public AdminForm(User user)
        {
            InitializeComponent();

     
            actions = new UIActions();

            //Load labels
            labelUsername.Text = user.Username;
            labelRole.Text = "Admin";


            //First load
            selectedEdit = SelectedEdit.User;

            actions.RemoveColumns(listView);

            listView.Columns.Add("Id");
            listView.Columns.Add("Username");
            listView.Columns.Add("Role");
            LoadData();
            actions.ResizeColumns(listView);


            label5.Text = selectedEdit.ToString();
            //Panels

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

        private void buttonMaximize_Click(object sender, EventArgs e)
        {
            actions.MaximizeApp(this);
        }

        private void buttonManageUsers_Click(object sender, EventArgs e)
        {
            actions.ClearData(listView);
            actions.RemoveColumns(listView);

            selectedEdit = SelectedEdit.User;
            label5.Text = selectedEdit.ToString();

            listView.Columns.Add("Id");
            listView.Columns.Add("Username");
            listView.Columns.Add("Role");

            LoadData();

            actions.ResizeColumns(listView);
      
        }
        private void buttonManageEmployees_Click(object sender, EventArgs e)
        {
            actions.ClearData(listView);
            actions.RemoveColumns(listView);

            selectedEdit = SelectedEdit.Employee;
            label5.Text = selectedEdit.ToString();

            listView.Columns.Add("Id");
            listView.Columns.Add("First Name");
            listView.Columns.Add("Last Name");
            listView.Columns.Add("Birthday");
            listView.Columns.Add("Email");
            listView.Columns.Add("Phonenumber");

            actions.ResizeColumns(listView);
        }

        private void buttonManageContracts_Click(object sender, EventArgs e)
        {
            actions.ClearData(listView);
            actions.RemoveColumns(listView);

            selectedEdit = SelectedEdit.Contract;
            label5.Text = selectedEdit.ToString();

            listView.Columns.Add("Id");
            listView.Columns.Add("Name");
            listView.Columns.Add("Description");
            listView.Columns.Add("Worker");
            listView.Columns.Add("Status");

            actions.ResizeColumns(listView);
        }

        private void LoadData()
        {
            if (selectedEdit == SelectedEdit.User)
            {
                users = SqlRepository.GetUsers();
                listView.Items.Clear();
                foreach (var user in users)
                {
                    ListViewItem listViewItem = new ListViewItem(new string[] {
                    user.Id.ToString(),
                    user.Username.ToString(),
                    user.Role.ToString()
                });
                    listView.Items.Add(listViewItem);
                    listView.Refresh();
                }
            }
        }

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            panelProfile.Visible = false;
        }

        private void buttonCancelChange_Click(object sender, EventArgs e)
        {
            panelProfile.Visible = true;

            textBoxNewPassword.Text = String.Empty;
            textBoxOldPassword.Text = String.Empty;

            show = false;
            textBoxNewPassword.PasswordChar = '●';
            textBoxOldPassword.PasswordChar = '●';
        }

        private void buttonShowPassword_Click(object sender, EventArgs e)
        {
            show = !show;

            if (show == true)
            {
                textBoxNewPassword.PasswordChar = '\0';
                textBoxOldPassword.PasswordChar = '\0';

            }
            else
            {
                textBoxNewPassword.PasswordChar = '●';
                textBoxOldPassword.PasswordChar = '●';
            }
        }

        private void buttonFinishChange_Click(object sender, EventArgs e)
        {

        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
           
        }
    }
}
