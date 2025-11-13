using card_game.Model;
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
    public partial class FM_CreateCard : Form
    {
        private int userId;
        private Image baseImage;

        public FM_CreateCard(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void TB_NumericOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BT_CC_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BT_ChooseImg_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog { Filter = "Imagens|*.png;*.jpg;*.jpeg;*.bmp" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                baseImage = Image.FromFile(ofd.FileName);
                PB_CreateImg.Image = baseImage;
            }
        }

        private void BT_SendCard_Click(object sender, EventArgs e)
        {
            if(TB_CardName.Text.Trim() == "" || TB_Damage.Text.Trim() == "" || TB_Life.Text.Trim() == "" || TB_shield.Text.Trim() == "")
            {
                MessageBox.Show("ERRO: empty info");
                return;
            }

            if(PB_CreateImg.Image == PB_CreateImg.InitialImage)
            {
                MessageBox.Show("ERRO: change image");
                return;
            }

            string name = TB_CardName.Text.Trim();
            int damage = int.Parse(TB_Damage.Text.Trim());
            int life = int.Parse(TB_Life.Text.Trim());
            int shield = int.Parse(TB_shield.Text.Trim());
            Image img = PB_CreateImg.Image;

            Card new_card = new Card(userId, name, img, life, damage, shield);

            string msg = CDeckUtil.sendCard(new_card);

            MessageBox.Show(msg);

            TB_CardName.Text = "";
            TB_Damage.Text = "";
            TB_Life.Text = "";
            TB_shield.Text = "";

            PB_CreateImg.Image = PB_CreateImg.InitialImage;



        }
    }
}
