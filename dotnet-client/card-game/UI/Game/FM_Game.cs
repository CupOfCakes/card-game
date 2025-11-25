using card_game.Domain.Entities;
using card_game.Infrastructure;
using card_game.Infrastructure.GameManegers;
using Microsoft.VisualBasic.ApplicationServices;
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
using UImg = card_game.Infrastructure.Images;
using card_game.Infrastructure;
using card_game.Infrastructure.GameManegers;

namespace card_game.UI.Game
{
    public partial class FM_Game : Form
    {
        List<Panel> deckPanels;
        

        List<Panel> enemyDefenseSlots;
        List<Panel> enemyAtackSlots;

        List<Panel> playerDefenseSlots;
        List<Panel> playerAtackSlots;

        private GameController game;

        public FM_Game(int userId)
        {
            InitializeComponent();

            game = new GameController();

            List<Card> deck = net.DeckClient.getDeck(userId);

            game.OnPlayerTurn += PlayerTurn;
            game.OnBotTurn += BotTurn;

            enemyDefenseSlots = new List<Panel>{
                EnemyDefense1,
                EnemyDefense2,
                EnemyDefense3
            };

            enemyAtackSlots = new List<Panel>{
                EnemyAtack1,
                EnemyAtack2,
                EnemyAtack3,
                EnemyAtack4,
                EnemyAtack5
            };

            playerDefenseSlots = new List<Panel>
            {
                PL_Defense1,
                PL_Defense2,
                PL_Defense3
            };

            playerAtackSlots = new List<Panel>
            {
                PL_Atack1,
                PL_Atack2,
                PL_Atack3,
                PL_Atack4,
                PL_Atack5
            };

            var slotGroups = new Dictionary<string, List<Panel>>
            {
                ["EnemyDefense"] = new List<Panel>
                    {
                        EnemyDefense1,
                        EnemyDefense2,
                        EnemyDefense3
                    },

                ["EnemyAttack"] = new List<Panel>
                    {
                        EnemyAtack1,
                        EnemyAtack2,
                        EnemyAtack3,
                        EnemyAtack4,
                        EnemyAtack5
                    },

                ["PlayerDefense"] = new List<Panel>
                    {
                        PL_Defense1,
                        PL_Defense2,
                        PL_Defense3
                    },

                ["PlayerAttack"] = new List<Panel>
                    {
                        PL_Atack1,
                        PL_Atack2,
                        PL_Atack3,
                        PL_Atack4,
                        PL_Atack5
                    }
            };

            PlayerStart(userId);
            BotStart();


        }

        private void PlayerTurn()
        {
            //change mode
            ToggleMode(true);

            //reset atack cards move
            foreach (var slot in playerAtackSlots)
            {
                if(slot.Controls.Count > 0)
                {
                    Panel cardPanel = (Panel)slot.Controls[0];
                    PictureBox pic = (PictureBox)cardPanel.Controls[0];

                    Card card = ((Card)pic.Tag);

                    card.Move = Math.Min(card.Move + 1, 1);
                }
            }
        }

        private void BotTurn()
        {
            ToggleMode(false);
        
        }

        private void ToggleMode(bool x)
        {

            BT_EndTurn.Visible = x;

            foreach (var slot in playerAtackSlots) slot.AllowDrop = x;

            foreach(var slot in playerDefenseSlots) slot.AllowDrop = x;

        }


        private void PlayerStart(int id)
        {
            List<Card> deck = net.GameClient.getDeckGame(id);

            deckPanels = CreateCardsPanel(deck);

            for (int i = 0; i < 3; i++)
            {
                GetCardOnDeck();
            }
        }

        private void BotStart()
        {
            List <Card> deckBot = net.GameClient.getDeckBotGame();

            game.SetBotDeck(CreateCardsPanel(deckBot));

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
                        Move = 0,
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
            if (!game.HaveGlobalMove()) return;

            Panel slot = (Panel)sender;
            Panel cardPanel = (Panel)e.Data.GetData(typeof(Panel));
            PictureBox pic = cardPanel.Controls.OfType<PictureBox>().FirstOrDefault();

            slot.Tag = pic.Tag;

            if (cardPanel.Parent is FlowLayoutPanel fp)
            {
                fp.Controls.Remove(cardPanel);
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
            game.GenericGlobalMove();

        }

        private void EnemySlot_DragDrop(object sender, DragEventArgs e)
        {

            Panel slot = (Panel)sender;
            PictureBox enemyPic = slot.Controls.OfType<PictureBox>().FirstOrDefault();

            Panel cardPanel = (Panel)e.Data.GetData(typeof(Panel));
            PictureBox pic = cardPanel.Controls.OfType<PictureBox>().FirstOrDefault();


            Card attacker = pic?.Tag as Card;
            Card defender = enemyPic?.Tag as Card;

            if (attacker == null || attacker.Move <= 0 ||
                cardPanel.Parent is FlowLayoutPanel || defender == null)
                return;


            if (slot.Name.StartsWith("EnemyAtack"))
            {
                foreach (var defense in enemyDefenseSlots)
                {
                    if (defense.Controls.Count > 0) return;
                }
            }


            bool isDefense = false;

            if (slot.Name.StartsWith("EnemyDefense"))
            {
                isDefense = true;
            }

            string result = game.ProcessAttack(attacker, defender, isDefense);

            string[] resultSplit = result.Split(':');

            string msg = resultSplit[0];
            int defenderChange = int.Parse(resultSplit[1]);
            int attacketChange = int.Parse(resultSplit[2]);

            switch (msg)
            {
                case "SHIELD BREAK":
                    slot.Controls.Clear();

                    foreach (var ASlot in enemyAtackSlots)
                    {
                        if (ASlot.Controls.Count <= 0)
                        {
                            ASlot.Controls.Add(enemyPic.Parent);
                            defender.Move--;
                            break;
                        }

                    }
                    break;

                case "SHIELD DAMAGE":
                    defender.Shield = defenderChange;
                    break;

                case "DEFENDER DEAD":
                    slot.Controls.Clear();
                    break;

                case "REVENGE ON SHIELD":
                    defender.Life = defenderChange;
                    attacker.Shield = attacketChange;
                    break;

                case "REVENGE ON LIFE":
                    defender.Life = defenderChange;
                    attacker.Life = attacketChange;
                    break;

                default:
                    MessageBox.Show("You found a new bug *_*, you really hate me, right?");
                    break;

            }

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

        

        private void BT_EndTurn_Click(object sender, EventArgs e)
        {
            game.EndTurn();
        }
    }
}
