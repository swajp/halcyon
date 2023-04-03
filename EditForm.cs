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
    public partial class EditForm : Form
    {
        UIActions actions;
        private string selectedEdit;
        private List<string> textBoxValues = new List<string>();
        public EditForm(string selectedEdit)
        {
            InitializeComponent();
            actions = new UIActions();
            this.selectedEdit = selectedEdit;
        }
        public void GenerateForm(string[] controlNames, string[] controlTypes, string[]? comboBoxItems, List<string> rowData)
        {
            int y = 10;
            for (int i = 0; i < controlNames.Length; i++)
            {
                if (controlNames[i].Contains("G"))
                {
                    Label label = new Label();
                    label.Text = controlNames[i].Replace("G", "") + ":";
                    label.Location = new Point(10, y);
                    label.AutoSize = true;
                    this.Controls.Add(label);
                }

                Control control;
                switch (controlTypes[i])
                {
                    case "TextBox":

                        control = new TextBox();
                        control.Text = rowData[i];
                        if (i == 0)
                        {
                            control.Enabled = false;
                        }

                        break;
                    case "ComboBox":
                        control = new ComboBox();
                        if (rowData[i] == "1")
                        {
                            control.Text = "Admin";
                        }
                        else
                        {
                            control.Text = "User";
                        }
                        ((ComboBox)control).Items.AddRange(comboBoxItems);
                        break;
                    case "Button":
                        control = new Button();
                        control.Text = controlNames[i].ToString();
                        control.Name = controlNames[i].ToString();
                        control.Click += (sender, e) =>
                        {
                            Button clickedButton = (Button)sender;
                            string buttonName = clickedButton.Name;

                            if (buttonName == "Close")
                            {
                                Close();
                            }
                            if (buttonName == "Edit")
                            {
                                Edit();
                            }
                        };
                        break;
                    case "DateTimePicker":
                        control = new DateTimePicker();
                        break;
                    default:
                        throw new ArgumentException(controlTypes[i]);
                }
                control.Location = new Point(120, y);
                control.Size = new Size(150, 20);
                this.Controls.Add(control);
                y += 30;
                AutoSizeForm();
            }
        }
        private void Edit()
        {
            List<string> data = new List<string>();

            foreach (Control control in Controls)
            {
                if (control is TextBox)
                {
                    data.Add((control as TextBox).Text);
                }
                else if (control is ComboBox)
                {
                    data.Add((control as ComboBox).SelectedIndex.ToString());
                }
                else if (control is DateTimePicker)
                {
                    data.Add((control as DateTimePicker).Value.ToString());
                }
            }
            DialogResult = DialogResult.OK;
            SqlRepository.EditRecord(selectedEdit, data);
            this.Hide();
        }
        private void Close(object sender, EventArgs e)
        {
            actions.CancelForm(this);
        }
        private void AutoSizeForm()
        {
            int maxHeight = 0;
            int maxWidth = 0;

            foreach (Control control in Controls)
            {
                if (control.Location.Y + control.Height > maxHeight)
                {
                    maxHeight = control.Location.Y + control.Height;
                }
                if (control.Location.X + control.Width > maxWidth)
                {
                    maxWidth = control.Location.X + control.Width;
                }
            }

            Size = new Size(maxWidth + 50, maxHeight + 100);
        }
    }
}
