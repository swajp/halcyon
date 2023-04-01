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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;

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
            LoadData(new string[] { "Id", "Username", "RoleId" });


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
            selectedEdit = SelectedEdit.User;
            LoadData(new string[] { "Id", "Username", "RoleId" });
        }
      
        private void buttonManageEmployees_Click(object sender, EventArgs e)
        {
            selectedEdit = SelectedEdit.Employee;
            //LoadData(new string[] { "Id, Job, Firstname, Lastname, Birthdate, Email, PhoneNumber" });
        }

        private void buttonManageContracts_Click(object sender, EventArgs e)
        {
            //selectedEdit = SelectedEdit.Contract;
            //LoadData();
            
        }
        
        private void LoadData(string[] columns)
        {
            actions.ClearData(listView);
            actions.RemoveColumns(listView);

            label5.Text = selectedEdit.ToString();

            object[] data;
            SqlRepository.GetData(selectedEdit.ToString(), columns, out data);

            for (int i = 0; i < columns.Length; i++)
            {
                columns[i] = Regex.Replace(columns[i], "(\\B[A-Z])", " $1");
                listView.Columns.Add(columns[i].ToString());
            }
            
            foreach (object dat in data)
            {
                ListViewItem listViewItem = new ListViewItem(data.Select(d => d.ToString()).ToArray());
                listView.Items.Add(listViewItem);
            }

            listView.Refresh();

            actions.ResizeColumns(listView);
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

        private void buttonAddRecord_Click(object sender, EventArgs e)
        {
            if (selectedEdit == SelectedEdit.User)
            {
                AddUser addUser = new AddUser();
                addUser.Show();
            }
            if (selectedEdit == SelectedEdit.Employee)
            {
                AddEmployee addEmployee = new AddEmployee(selectedEdit.ToString());
                addEmployee.Show();
            }
        }
    }
}
