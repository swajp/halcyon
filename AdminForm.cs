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


            selectedEdit = SelectedEdit.User;
            List<string> columnNames = new List<string> { "Id", "Username", "RoleId" };
            SqlRepository.FillListView("Users", columnNames,listView);


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
            List<string> columnNames = new List<string> { "Id", "Username", "RoleId" };
            SqlRepository.FillListView("Users", columnNames, listView);
        }
      
        private void buttonManageEmployees_Click(object sender, EventArgs e)
        {
            selectedEdit = SelectedEdit.Employee;
            List<string> columnNames = new List<string> { "EmployeeId", "Job", "FirstName", "LastName", "BirthDate", "Email", "PhoneNumber" };
            SqlRepository.FillListView("Employees", columnNames, listView);
        }

        private void buttonManageContracts_Click(object sender, EventArgs e)
        {
            selectedEdit = SelectedEdit.Contract;
            //LoadData(new string[] { "" });

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
            this.Hide();
            LoadinForm loadinForm = new LoadinForm();
            loadinForm.Show();
        }

        private void buttonAddRecord_Click(object sender, EventArgs e)
        {
            AddForm addEmployee = new AddForm(selectedEdit.ToString());

            if (selectedEdit == SelectedEdit.User)
            {
                string[] controlNames = { "UsernameG", "PasswordG", "PasswordAgainG", "RoleG", "Close", "Add" };
                string[] controlTypes = { "TextBox", "TextBox", "TextBox", "ComboBox", "Button", "Button" };
                string[] comboBoxItems = { "User", "Admin" };
                addEmployee.GenerateForm(controlNames, controlTypes, comboBoxItems);
            }
            if (selectedEdit == SelectedEdit.Employee)
            {
                string[] controlNames = { "JobG", "FirstNameG", "LastnameG", "BirthdateG", "Phone NumberG", "Close", "Add" };
                string[] controlTypes = { "TextBox", "TextBox", "TextBox", "DateTimePicker", "TextBox", "Button", "Button" };
                addEmployee.GenerateForm(controlNames, controlTypes, null);
            }
            if (selectedEdit == SelectedEdit.Contract)
            {
                string[] controlNames = { "Contract NameG", "DescriptionG", "StatusG", "WorkerG", "TimeG", "Close", "Add" };
                string[] controlTypes = { "TextBox", "TextBox", "TextBox", "TextBox", "DateTimePicker", "Button", "Button" };
                addEmployee.GenerateForm(controlNames, controlTypes, null);
            }
            addEmployee.Show();
        }
    }
}
