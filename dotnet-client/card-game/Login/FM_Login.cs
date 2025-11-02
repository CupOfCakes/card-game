using System.Net.Sockets;
using System.Text;

namespace card_game
{
    public partial class FM_Login : Form
    {
        public FM_Login()
        {
            InitializeComponent();

            this.AcceptButton = BT_SignIn;
        }

        private void BT_SignIn_Click(object sender, EventArgs e)
        {

            string user = TB_User.Text;
            string password = TB_Password.Text;

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("ERRO: user or password empty");
                return;
            }

            string result = LoginClient.SendLogin(user, password);

            if (result.StartsWith("LOGIN_OK"))
            {
                string idPart = result.Substring(9); 
                int userID = int.Parse(idPart);
                MessageBox.Show("Login bem-sucedido!");
            }
            else MessageBox.Show(result);
        }

        private void LL_SignUP_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form SignUp = new FM_SignUp(this);
            this.Hide();
            SignUp.ShowDialog();
            this.Show();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                BT_SignIn.PerformClick();
                e.Handled = true;
            }
        }

        private void LL_FP_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form FM_FP = new FM_ForgetPassword(this);
            this.Hide();
            FM_FP.ShowDialog();
            this.Show();
        }
    }
}
