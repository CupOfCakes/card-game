using card_game.Infrastructure.Network;
using card_game.UI.Game;
using card_game.UI.Shared;
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

        public event Action Logoff;
        private FM_Login loginForm;

        private bool isLogoff = false;

        public FM_MainScreen(int userId, FM_Login login)
        {
            InitializeComponent();
            FormClosed += FM_MainScreen_FormClosed;
            LB_name.Text = MainClient.NameClient(userId);
            this.userId = userId;
            loginForm = login;
        }

        private void FM_MainScreen_FormClosed(object? sender, FormClosedEventArgs e)
        {
            if(!isLogoff) Application.Exit();

        }

        private void LB_name_Click(object sender, EventArgs e)
        {

        }

        private void FM_MainScreen_Load(object sender, EventArgs e)
        {

        }

        private void BT_Deck_Click(object sender, EventArgs e)
        {
            Form load = new FM_loading(() => new FM_Deck(userId));
            load.ShowDialog();
        }

        public void BT_Logoff_Click(object sender, EventArgs e)
        {

        }

        private void BT_Play_Click(object sender, EventArgs e)
        {
            Form load = new FM_loading(() => new FM_Game(userId));
            load.ShowDialog();
        }

        private void BT_Config_Click(object sender, EventArgs e)
        {
            var config = new FM_Config(userId);
            config.OnLogout += Config_OnLogout;
            config.ShowDialog();
        }

        private void Config_OnLogout()
        {
            isLogoff = true;
            loginForm.Show();
            this.Close(); 
        }
    }
}
