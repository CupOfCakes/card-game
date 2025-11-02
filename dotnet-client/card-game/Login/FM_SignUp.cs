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
    public partial class FM_SignUp : Form
    {
        private FM_Login _SignIn;

        public FM_SignUp(FM_Login SignInForm)
        {
            InitializeComponent();
            _SignIn = SignInForm;

            this.AcceptButton = BT_SignUP;
        }

        private void LL_SignUP_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _SignIn.Show();
            this.Close();
        }

        private void BT_SignUP_Click(object sender, EventArgs e)
        {
            string user = TB_SU_User.Text;
            string password = TB_SU_Password.Text;

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("ERRO: user or password empty");
                return;
            }

            string result = LoginClient.NewLogin(user, password);

            MessageBox.Show(result);

        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                BT_SignUP.PerformClick();
                e.Handled = true;
            }
        }

    }
}
