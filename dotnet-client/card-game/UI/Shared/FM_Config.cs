using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace card_game.UI.Shared
{
    public partial class FM_Config : Form
    {
        public event Action OnLogout;

        public FM_Config()
        {
            InitializeComponent();
        }

        private void BT_Logoff_Click(object sender, EventArgs e)
        {
            this.Close();
            OnLogout?.Invoke();
        }

        private void BT_Delete_Click(object sender, EventArgs e)
        {
            
        }

    }
}
