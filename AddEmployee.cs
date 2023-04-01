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
    public partial class AddEmployee : Form
    {
        UIActions actions;
        public AddEmployee(string selectedEdit)
        {
            InitializeComponent();
            actions = new UIActions();

            Label title = new Label();
            title.Text = "Add" + selectedEdit;
            title.Location = new Point(10, 10);
            title.Font = new Font(Font, FontStyle.Bold);
            this.Controls.Add(title);

            string[] labels = { "Username", "Password", "Password Again, Role" };
            string[] textBoxes = { "textBoxUsername", "textBoxPassword", "textBoxPasswordAgain" };

            int buttonY = 50;
            for (int i = 0; i < labels.Length; i++)
            {
                Label label = new Label();
                label.Text = labels[i];
                label.Location = new Point(10, 50 + i * 30); 
                this.Controls.Add(label);

                TextBox textBox = new TextBox();
                textBox.Name = textBoxes[i]; 
                textBox.Location = new Point(150, 50 + i * 30); 
                textBox.Size = new Size(80, 20);
                this.Controls.Add(textBox);

                buttonY += 30;
            }

            if (selectedEdit == "Employees")
            {
                ComboBox comboBox = new ComboBox();
                comboBox.Items.Add("user");
                comboBox.Items.Add("admin");
                comboBox.SelectedIndex = 0;
                comboBox.Location = new Point(80, buttonY); // umístění ComboBoxu nad tlačítkem "OK"
                this.Controls.Add(comboBox);

                Button createButton = new Button();
                createButton.Text = "Add " + selectedEdit;
                createButton.Location = new Point(150, buttonY + 30); // umístění tlačítka pod posledním textovým polem
                createButton.Click += createButton_Click; // připojení metody obsluhy události pro kliknutí na tlačítko
                this.Controls.Add(createButton);

                Button closeButton = new Button();
                closeButton.Text = "Cancel";
                closeButton.Location = new Point((createButton.Location.X - (createButton.Location.X / 2 + 4)), buttonY + 30);
                
                closeButton.Click += closeButton_Click;
                this.Controls.Add(closeButton);
            }

        }

        private void closeButton_Click(object? sender, EventArgs e)
        {
            actions.CancelForm(this);
        }

        private void createButton_Click(object? sender, EventArgs e)
        {
            
        }
    }
}
