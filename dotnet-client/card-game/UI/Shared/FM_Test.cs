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
    public partial class FM_Test : Form
    {
        public FM_Test(Image img)
        {
            InitializeComponent();

            pictureBox1.Image = img;
        }
    }
}
