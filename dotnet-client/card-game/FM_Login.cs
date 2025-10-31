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

            if (result == "LOGIN_OK")
                MessageBox.Show("Login bem-sucedido!");
            else
                MessageBox.Show("Falha no login!");
        }

        private void LL_SignUP_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form SignUp = new FM_SignUp(this);
            SignUp.Show();
            this.Hide();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e) 
        {
            if (e.KeyChar == (char)Keys.Enter) 
            { 
                BT_SignIn.PerformClick();
                e.Handled = true;
            }
        }

    }
}
