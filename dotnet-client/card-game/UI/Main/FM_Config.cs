using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using net = card_game.Infrastructure.Network;

namespace card_game.UI.Shared
{
    public partial class FM_Config : Form
    {
        public event Action OnLogout;
        private int id;

        public FM_Config(int userId)
        {
            InitializeComponent();
            id = userId;
        }

        private void BT_Logoff_Click(object sender, EventArgs e)
        {
            Logoff();
        }

        private void BT_Delete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                    "Are you sure you want to delete your account",
                    "Confirm deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

            if (result == DialogResult.Yes) {
                string resp = net.ConfigClient.DeleteAccount(id);
                MessageBox.Show(resp);
                Logoff();
            }
            
        }

        private void Logoff()
        {
            this.Close();
            OnLogout?.Invoke();
        }

    }
}
