namespace Halcyon
{
    public partial class LoadinForm : Form
    {
        public LoadinForm()
        {
            InitializeComponent();
        }

       private void timerLoading_Tick(object sender, EventArgs e)
        {
            panelLoading.Width += 3;

            if(panelLoading.Width >= 650)
            {
                timerLoading.Stop();

                this.Hide();

                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
        }
    }
}