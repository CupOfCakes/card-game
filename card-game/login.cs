using System.Net.Sockets;
using System.Text;

namespace card_game
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();

        }

        private void BT_SignIn_Click(object sender, EventArgs e)
        {
            string result = LoginClient.SendLogin(TB_User.Text, TB_Password.Text);

            if (result == "LOGIN_OK")
                MessageBox.Show("Login bem-sucedido!");
            else
                MessageBox.Show("Falha no login!");
        }
    }
}
