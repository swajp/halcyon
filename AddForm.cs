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
    public partial class AddForm : Form
    {
        UIActions actions;
        public AddForm(string selectedEdit)
        {
            InitializeComponent();
            actions = new UIActions();
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
                            else if (buttonName == "button2")
                            {

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

                y += 30;
                AutoSizeForm();
            }
        }
        private void Close(object sender, EventArgs e)
        {
            actions.CancelForm(this);
        }
        private void Add(object sender, EventArgs e)
        {

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
