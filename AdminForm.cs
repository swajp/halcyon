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

namespace Halcyon
{
    public partial class AdminForm : Form
    { 
        UIActions actions;
        private List<User> users;

        bool show = false;
        string role;
        static class SelectedEdit
        {
            public const string User = "Users";
            public const string Employee = "Employees";
            public const string Contract = "Contracts";
            public const string Work = "Works";
        }

        string selectedEdit;
        public AdminForm(User user)
        {
            InitializeComponent();

            actions = new UIActions();

            //Load labels
            labelUsername.Text = user.Username;
            labelRole.Text = "";

            role = user.Role.ToString(); ;

            if (role == "1")
            {
                selectedEdit = SelectedEdit.User;
                LoadBySelect();

            }
            else if (role == "0")
            {
                selectedEdit = SelectedEdit.Employee;
                LoadBySelect();
            }
        }
        public AdminForm()
        {
            selectedEdit = SelectedEdit.User;
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
            LoadBySelect();
        }
      
        private void buttonManageEmployees_Click(object sender, EventArgs e)
        {
            selectedEdit = SelectedEdit.Employee;
            LoadBySelect();
        }
        private void buttonManageWorks_Click(object sender, EventArgs e)
        {
            selectedEdit = SelectedEdit.Work;
            LoadBySelect();
        }
        private void buttonManageContracts_Click(object sender, EventArgs e)
        {
            selectedEdit = SelectedEdit.Contract;
            LoadBySelect();

        }
        public void LoadBySelect()
        {
            if (role == "1")
            {
                if (selectedEdit == SelectedEdit.User)
                {
                    List<string> columnNames = new List<string> { "Id", "Username", "RoleId" };
                    SqlRepository.GetData("Users", columnNames, listView);
                    buttonEditRecord.Enabled = true;
                }
                else if (selectedEdit == SelectedEdit.Employee)
                {
                    List<string> columnNames = new List<string> { "EmployeeId", "Job", "FirstName", "LastName", "BirthDate", "Email", "PhoneNumber" };
                    SqlRepository.GetData("Employees", columnNames, listView);
                    buttonEditRecord.Enabled = true;
                }
                else if (selectedEdit == SelectedEdit.Contract)
                {
                    List<string> columnNames = new List<string> { "ContractId", "Works", "Employees", "CustomerName", "DateAdded", "NumberOfHours" };
                    SqlRepository.GetData("Contract", columnNames, listView);
                    buttonEditRecord.Enabled = false;

                }
                else if (selectedEdit == SelectedEdit.Work)
                {
                    selectedEdit = SelectedEdit.Work;
                    List<string> columnNames = new List<string> { "WorkId", "Name", "Description" };
                    SqlRepository.GetData("Works", columnNames, listView);
                    buttonEditRecord.Enabled = true;
                }
            }
            else if (role == "0")
            {
                buttonManageUsers.Enabled = false;
                buttonManageEmployees.Enabled = false;

                if (selectedEdit == SelectedEdit.Contract)
                {
                    List<string> columnNames = new List<string> { "ContractId", "Works", "Employees", "CustomerName", "DateAdded", "NumberOfHours" };
                    SqlRepository.GetData("Contract", columnNames, listView);
                    buttonEditRecord.Enabled = false;

                }
                else if (selectedEdit == SelectedEdit.Work)
                {
                    selectedEdit = SelectedEdit.Work;
                    List<string> columnNames = new List<string> { "WorkId", "Name", "Description" };
                    SqlRepository.GetData("Works", columnNames, listView);
                    buttonEditRecord.Enabled = true;
                    buttonAddRecord.Enabled = false;
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
            this.Hide();
            LoadinForm loadinForm = new LoadinForm();
            loadinForm.Show();
        }

        private void buttonAddRecord_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm(selectedEdit.ToString());

            if (selectedEdit == SelectedEdit.User)
            {
                string[] controlNames = { "UsernameG", "PasswordG", "RoleG", "Close", "Add" };
                string[] controlTypes = { "TextBox", "TextBox", "ComboBox", "Button", "Button" };
                string[] comboBoxItems = { "User", "Admin" };
                addForm.GenerateForm(controlNames, controlTypes, comboBoxItems);

            }
            else if (selectedEdit == SelectedEdit.Employee)
            {
                string[] controlNames = { "JobG", "FirstNameG", "LastnameG", "BirthDayG", "EmailG", "Phone NumberG", "Close", "Add" };
                string[] controlTypes = { "TextBox", "TextBox", "TextBox", "DateTimePicker", "TextBox", "TextBox", "Button", "Button" };
                addForm.GenerateForm(controlNames, controlTypes, null);
            }
            else if (selectedEdit == SelectedEdit.Contract)
            {
                string[] controlNames = { "WorkIdG", "EmployeeIdG", "CustomerG", "DateAddedG", "HoursG", "Close", "Add" };
                string[] controlTypes = { "TextBox", "TextBox", "TextBox", "DateTimePicker", "TextBox", "Button", "Button" };
                addForm.GenerateForm(controlNames, controlTypes, null);
            }
            else if (selectedEdit == SelectedEdit.Work)
            {
                string[] controlNames = { "Work NameG", "DescriptionG", "Close", "Add" };
                string[] controlTypes = { "TextBox", "TextBox", "Button", "Button" };
                addForm.GenerateForm(controlNames, controlTypes, null);
            }
            var result = addForm.ShowDialog();
            if (result == DialogResult.OK)
                LoadBySelect();
        }
        private void buttonEditRecord_Click(object sender, EventArgs e)
        {
            EditForm editForm = new EditForm(selectedEdit.ToString());

            List<string> rowData = new List<string>();
            ListViewItem selectedItem = listView.SelectedItems[0];

            foreach (ListViewItem.ListViewSubItem subItem in selectedItem.SubItems)
            {
                rowData.Add(subItem.Text);
            }

            if (selectedEdit == SelectedEdit.User)
            {
                string[] controlNames = {"IdG", "UsernameG", "RoleG", "Close", "Edit" };
                string[] controlTypes = {"TextBox", "TextBox",  "ComboBox", "Button", "Button" };
                string[] comboBoxItems = { "User", "Admin" };
                editForm.GenerateForm(controlNames, controlTypes, comboBoxItems, rowData);
            }
            if (selectedEdit == SelectedEdit.Employee)
            {
                string[] controlNames = { "EmployeeIdG", "JobG", "FirstNameG", "LastnameG", "BirthDayG", "EmailG", "Phone NumberG", "Close", "Edit" };
                string[] controlTypes = { "TextBox", "TextBox", "TextBox", "TextBox", "DateTimePicker", "TextBox", "TextBox", "Button", "Button" };
                editForm.GenerateForm(controlNames, controlTypes, null, rowData);
            }
            if (selectedEdit == SelectedEdit.Work)
            {
                string[] controlNames = { "WorkIdG", "NameG", "DescriptionG", "Close", "Edit" };
                string[] controlTypes = { "TextBox", "TextBox", "TextBox", "Button", "Button" };
                editForm.GenerateForm(controlNames, controlTypes, null, rowData);
            } 
            var result = editForm.ShowDialog();
            if (result == DialogResult.OK)
                LoadBySelect();
        }
        private void buttonDownload_Click(object sender, EventArgs e)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string fileName = selectedEdit.ToString()+".csv";
            string filePath = Path.Combine(desktopPath, fileName);
            SqlRepository.ExportListViewToCsv(listView, filePath);

        }
        private void buttonRemoveRecord_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Row isn't selected");
            }
            else
            {
                var selectedRow = listView.SelectedItems[0];
                var columnName = listView.Columns[0].Text;
                string selectedValue = selectedRow.SubItems[0].Text;
                selectedValue = columnName.Replace(" ", "");
                var id = selectedRow.SubItems[0].Text;

                SqlRepository.DeleteRecord(selectedEdit, selectedValue,id);
                listView.SelectedItems[0].Remove();
            }
        }

    }
}
