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
using card_game.Domain.Entities;
using UImg = card_game.Infrastructure.Images;
using card_game.Infrastructure;
using card_game.Infrastructure.GameManegers;

namespace card_game.UI.Game
{
    public partial class FM_Game : Form
    {
        enum round
        {
            player,
            bot
        }

        List<Card> deck;
        List<Panel> deckPanels;

        List<Card> deckBot;
        List<Panel> deckBotPanels;

        private GameController game;

        public FM_Game(int userId)
        {
            InitializeComponent();

            game = new GameController();

            deck = net.DeckClient.getDeck(userId);

            Random rnd = new Random();

            deck = deck.OrderBy(c => rnd.Next()).ToList();

            deckPanels = CreateCardsPanel(deck);

            for (int i = 0; i < 3; i++)
            {
                GetCardOnDeck();
            }

        }


        private List<Panel> CreateCardsPanel(List<Card> cards)
        {
            List<Panel> retorn = new List<Panel>();

            foreach (var card in cards)
            {
                var cardPanel = new Panel
                {
                    Width = 150,
                    Height = 225,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(15),
                };

                var pic = new PictureBox
                {
                    Image = card.CardImage,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Dock = DockStyle.Fill,
                    Tag = new Card
                    {
                        Life = card.Life,
                        Damage = card.Damage,
                        Shield = card.Shield,
                        Move = 1,
                    }
                };

                pic.MouseDown += (s, e) =>
                {
                    cardPanel.DoDragDrop(cardPanel, DragDropEffects.Move);
                };


                cardPanel.Controls.Add(pic);
                retorn.Add(cardPanel);

            }

            return retorn;

        }

        private void Slot_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Panel)))
                e.Effect = DragDropEffects.Move;
        }

        private void Slot_DragDrop(object sender, DragEventArgs e)
        {
            Panel slot = (Panel)sender;
            Panel cardPanel = (Panel)e.Data.GetData(typeof(Panel));
            PictureBox pic = cardPanel.Controls.OfType<PictureBox>().FirstOrDefault();

            slot.Tag = pic.Tag;

            if (cardPanel.Parent is FlowLayoutPanel fp)
            {
                fp.Controls.Remove(cardPanel);
            }
            else if (cardPanel.Parent is Panel oldSlot)
            {
                return;
            }

            if (slot.Controls.Count > 0) return;

            if (slot.Name.StartsWith("PL_Defense"))
            {
                pic.Image = UImg.ImageUtils.RotateImage(pic.Image);
                cardPanel.Dock = DockStyle.Fill;
            }

            ((Card)pic.Tag).Move -= 1;

            cardPanel.Dock = DockStyle.Fill;
            slot.Controls.Add(cardPanel);

        }

        private void Deck_Click(object sender, EventArgs e)
        {
            if(game.HaveGlobalMove())
            {
                GetCardOnDeck();
                game.GenericGlobalMove();
            }
            
        }

        private void GetCardOnDeck()
        {
            LP_Hand.Controls.Add(deckPanels[0]);
            deckPanels.Add(deckPanels[0]);
            deckPanels.RemoveAt(0);
                 
        }

        private void PlayerTurnUI()
        {
            
        }

        private void BotTurnUI()
        {

        }

    }
}
