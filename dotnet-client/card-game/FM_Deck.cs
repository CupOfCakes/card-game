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
    public partial class FM_Deck : Form
    {
        private int userId;
        const int decksize = 10;
        Panel[] deckslots;

        public FM_Deck(int userId)
        {
            InitializeComponent();

            LP_Deck.DragEnter += LP_Deck_DragEnter;
            LP_Deck.DragOver += LP_Deck_DragOver;

            LP_Cards.DragEnter += LP_Cards_DragEnter;
            LP_Cards.DragOver += LP_Cards_DragOver;

            MainPanel.DragOver += MainPanel_DragOver;

            var userDeck = DeckCode.getDeck(userId);

            CreateDeckSlot(userDeck);

            var offDeck = DeckCode.getOffDeckCards(userId);

            ShowCardsDeck(offDeck, LP_Cards);

            this.userId = userId;

            int cardWidth = 200;
            int cardHeight = 300;
            int spacing = 15;
            int maxColumns = 5;

            // Ajusta o LP_Deck
            int deckRows = (int)Math.Ceiling(decksize / (double)maxColumns);
            LP_Deck.Width = (cardWidth + spacing * 2) * maxColumns;
            LP_Deck.Height = (cardHeight + spacing * 2) * deckRows;

            // Ajusta o LP_Cards (soltos) para vir logo abaixo do LP_Deck
            int cardsCount = LP_Cards.Controls.Count;
            int cardRows = (int)Math.Ceiling(cardsCount / (double)maxColumns);

        }


        private void LP_Deck_DragEnter(object s, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Panel)))
                e.Effect = DragDropEffects.Move;
        }

        private void LP_Deck_DragOver(object s, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void LP_Cards_DragEnter(object s, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Panel)))
                e.Effect = DragDropEffects.Move;
        }

        private void LP_Cards_DragDrop(object s, DragEventArgs e)
        {
            Panel cardPanel = (Panel)e.Data.GetData(typeof(Panel));

            if(cardPanel.Parent is Panel oldSlot)
            {
                oldSlot.Controls.Clear();
                oldSlot.Tag = 0;
                oldSlot.BackColor = Color.White;
            }

            cardPanel.Dock = DockStyle.None;
            LP_Cards.Controls.Add(cardPanel);
        }

        private void LP_Cards_DragOver(object s, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void MainPanel_DragOver(object s, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }


        void ShowCardsDeck(List<Card> deck, FlowLayoutPanel LP)
        {
            LP.Controls.Clear();

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
                    Dock = DockStyle.Fill,
                    Tag = card.CardId,
                };

                picture.MouseDown += (s, e) =>
                {
                    panel.DoDragDrop(panel, DragDropEffects.Move);
                };

                panel.Controls.Add(picture);
                LP.Controls.Add(panel);
            }

        }

        private void BT_CreateCard_Click(object sender, EventArgs e)
        {
            Form FMcreateCard = new FM_CreateCard(userId);
            FMcreateCard.ShowDialog();

        }

        private void BT_Back_Click(object sender, EventArgs e)
        {
            this.Close();
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

            if (pic == null)
            {
                MessageBox.Show("Erro: painel sem PictureBox.");
                return;
            }

            // Salva o ID da carta no slot
            slot.Tag = pic.Tag;

            // remover de onde estava
            if (cardPanel.Parent is FlowLayoutPanel fp)
            {
                fp.Controls.Remove(cardPanel);
            }
            else if (cardPanel.Parent is Panel oldSlot)
            {
                oldSlot.Controls.Clear();
                oldSlot.Tag = 0;
            }

            // se já tem carta, devolve pro LP_Cards
            if (slot.Controls.Count > 0)
            {
                Panel oldCard = (Panel)slot.Controls[0];
                slot.Controls.Clear();
                oldCard.Dock = DockStyle.None;
                LP_Cards.Controls.Add(oldCard);
            }

            // coloca a nova carta
            cardPanel.Dock = DockStyle.Fill;
            slot.Controls.Add(cardPanel);
            slot.BackColor = Color.White;

        }

        private void Panel_dragDropAnywhere(object sender, DragEventArgs e)
        {
            Panel cardPanel = (Panel)e.Data.GetData(typeof(Panel));

            if (!(cardPanel.Parent is FlowLayoutPanel) && !(cardPanel.Parent is Panel))
            {
                cardPanel.Dock = DockStyle.None;
                LP_Cards.Controls.Add(cardPanel);
            }
        }

        void CreateDeckSlot(List<Card> userDeck)
        {
            LP_Deck.Controls.Clear();
            deckslots = new Panel[decksize];

            for (int i = 0; i < decksize; i++)
            {
                Panel slot = new Panel
                {
                    Width = 200,
                    Height = 300,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(15),
                    BackColor = Color.White,
                    AllowDrop = true,
                };

                slot.DragEnter += Slot_DragEnter;
                slot.DragDrop += Slot_DragDrop;
                slot.Tag = 0;

                deckslots[i] = slot;
                LP_Deck.Controls.Add(slot);

            }

            int t = 0;
            foreach (var card in userDeck)
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
                    Dock = DockStyle.Fill,
                    Tag = card.CardId,
                };

                picture.MouseDown += (s, e) =>
                {
                    panel.DoDragDrop(panel, DragDropEffects.Move);
                };

                panel.Controls.Add(picture);

                Panel slot = deckslots[t];
                slot.Controls.Add(panel);
                slot.Tag = userDeck[t].CardId;

                t++;
                
            }

        }

        private List<int> GetDeckIds()
        {
            List<int> ids = new List<int>();

            foreach (var slot in deckslots)
            {
                if (slot.Tag != null)
                {
                    ids.Add((int) slot.Tag);
                }
                else
                {
                    ids.Add(0);
                }
            }

            return ids;

        }

        private void BT_SaveDeck_Click(object sender, EventArgs e)
        {
            List<int> deck = GetDeckIds();

            DeckCode.saveDeck(deck, userId);
            
        }
    }
}
