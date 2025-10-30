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
        private login _SignIn;

        public FM_SignUp(login SignInForm)
        {
            InitializeComponent();
            _SignIn = SignInForm;
        }

        private void LL_SignUP_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _SignIn.Show();
            this.Close();
        }
    }
}
