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

//140 x 200 tamanho das cartas no deck

namespace card_game
{
    public partial class FM_Deck : Form
    {
        private int userId;

        public FM_Deck(int userId)
        {
            InitializeComponent();

            var deck = DeckCode.getDeck(userId);

            ShowCardsDeck(deck);

            this.userId = userId;

        }

        void ShowCardsDeck(List<Card> deck)
        {
            LP_Deck.Controls.Clear();

            foreach (var card in deck)
            {
                var panel = new Panel
                {
                    Width = 200,
                    Height = 300,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(15)
                };

                var picture = new PictureBox
                {
                    Image = card.CardImage ?? card.BaseImage,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Dock = DockStyle.Top,
                    Height = 120
                };

                panel.Controls.Add(picture);
                LP_Deck.Controls.Add(panel);
            }

        }

        private void BT_CreateCard_Click(object sender, EventArgs e)
        {
            Form FMcreateCard = new FM_CreateCard(userId);
            FMcreateCard.ShowDialog();

        }
    }
}
