using card_game.Infrastructure.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace card_game
{
    public partial class FM_ForgetPassword : Form
    {
        private FM_Login _Login;

        public FM_ForgetPassword(FM_Login LoginForm)
        {
            InitializeComponent();
            _Login = LoginForm;

            this.AcceptButton = BT_ChangePassword;
        }

        private void BT_FP_Back_Click(object sender, EventArgs e)
        {
            _Login.Show();
            this.Close();
        }

        private void BT_ChangePassword_Click(object sender, EventArgs e)
        {

            string user = TB_FP_User.Text;
            string password = TB_FP_Password.Text;

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("ERRO: user or password empty");
                return;
            }

            string result = LoginClient.ChangeLogin(user, password);

            MessageBox.Show(result);

        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                BT_ChangePassword.PerformClick();
                e.Handled = true;
            }
        }

    }
}
