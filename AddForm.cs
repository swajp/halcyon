using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Halcyon
{
    public partial class AddForm : Form
    {
        UIActions actions;
        private string selectedEdit;
        private List<string> textBoxValues = new List<string>();
        public AddForm(string selectedEdit)
        {
            InitializeComponent();
            actions = new UIActions();
            this.selectedEdit = selectedEdit;
        }
        public void GenerateForm(string[] controlNames, string[] controlTypes, string[]? comboBoxItems)
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
                        break;
                    case "ComboBox":
                        control = new ComboBox();
                        ((ComboBox)control).Items.AddRange(comboBoxItems);
                        control.Text = comboBoxItems[0];
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
                            if (buttonName == "Add")
                            {
                                Add();
                            }
                        };
                        break;
                    case "DateTimePicker":
                        control = new DateTimePicker();
                        break;
                    // add other types here
                    default:
                        throw new ArgumentException(controlTypes[i]);
                }
                control.Location = new Point(120, y);
                control.Size = new Size(150, 20);
                this.Controls.Add(control);

                if (control is TextBox)
                {
                    ((TextBox)control).TextChanged += (sender, e) =>
                    {
                        TextBox textBox = (TextBox)sender;
                        int index = Array.IndexOf(controlNames, textBox.Name);
                        if (index >= 0)
                        {
                            if (textBoxValues.Count > index)
                            {
                                textBoxValues[index] = textBox.Text;
                            }
                            else
                            {
                                textBoxValues.Add(textBox.Text);
                            }
                        }
                    };
                }

                y += 30;
                AutoSizeForm();
            }
        }

        private void Add()
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
            SqlRepository.AddRecord(selectedEdit, data);
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
