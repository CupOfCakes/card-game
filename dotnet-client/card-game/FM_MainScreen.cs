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
    public partial class FM_MainScreen : Form
    {
        private int userId;

        public FM_MainScreen(int userId)
        {
            InitializeComponent();
            LB_name.Text = MainClient.NameClient(userId);
            this.userId = userId;
        }

        private void LB_name_Click(object sender, EventArgs e)
        {

        }

        private void FM_MainScreen_Load(object sender, EventArgs e)
        {

        }

        private void BT_Deck_Click(object sender, EventArgs e)
        {
            Form deckForm = new FM_Deck(userId);
            deckForm.ShowDialog();
        }

        private void BT_Logoff_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
