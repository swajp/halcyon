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
    public partial class AddUser : Form
    {
        UIActions actions;
        public AddUser()
        {
            InitializeComponent();
            actions = new UIActions();

            comboBoxRole.SelectedItem = "User";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            actions.CancelForm(this);
        }
    }
}
