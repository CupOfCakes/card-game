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

            string result = LoginClient.NewLogin(user, password);

            MessageBox.Show(result);



        }
    }
}
