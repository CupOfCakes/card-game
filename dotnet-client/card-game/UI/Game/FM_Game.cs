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

        private GameController game;

        Dictionary<string, List<Panel>> StatusArena;

        public FM_Game(int userId)
        {
            InitializeComponent();

            game = new GameController();

            List<Card> deck = net.DeckClient.getDeck(userId);

            game.OnPlayerTurn += PlayerTurnUI;
            game.OnBotTurn += BotTurnUI;
            game.OnGetStatusArena += GetStatusArena;
            game.OnSetStatusArena += SetStatusArena;
            game.OnBotAttackUI += (sender, e) =>
            {
                ApplyAttackResult(e.Result, e.Attacker, e.Defender, e.Slot, e.isPLayer);
            };
            game.OnLB_GM += (sender, e) =>
            {
                int gm = game.GetGM();
                LB_GM.Text = $"GM: {gm}";
            };
            game.OnGB_Life += changeGB_Life;
            game.OnEndGame += (sender, e) =>
            {
                MessageBox.Show($"{e.winner} Win!!!");
                this.Close();
            };


            StatusArena = new Dictionary<string, List<Panel>>
            {
                ["BotDefense"] = new List<Panel>
                    {
                        EnemyDefense1,
                        EnemyDefense2,
                        EnemyDefense3
                    },

                ["BotAttack"] = new List<Panel>
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
            game.StartGame();


        }

        private void changeGB_Life()
        {
            int pl = game.GetPlayerLife();
            int bl = game.GetBotLife();

            LB_BotLife.Text = $"Bot: {bl}";
            LB_PlayerLife.Text = $"Player: {pl}";
        }

        public Dictionary<string, List<Panel>> GetStatusArena()
        {
            return StatusArena;
        }

        public void SetStatusArena(Dictionary<string, List<Panel>> arena)
        {
            StatusArena = arena;
        }


        private void PlayerTurnUI()
        {
            //change mode
            ToggleMode(true);

            //reset atack cards move
            foreach (var slot in StatusArena["PlayerAttack"]) //playerAtackSlots
            {
                if (slot.Controls.Count > 0)
                {
                    Panel cardPanel = (Panel)slot.Controls[0];
                    PictureBox pic = (PictureBox)cardPanel.Controls[0];

                    Card card = ((Card)pic.Tag);

                    card.Move = Math.Min(card.Move + 1, 1);
                }
            }
        }

        private void BotTurnUI()
        {
            ToggleMode(false);

        }

        private void ToggleMode(bool x)
        {

            BT_EndTurn.Visible = x;

            foreach (var slot in StatusArena["PlayerAttack"]) slot.AllowDrop = x;

            foreach (var slot in StatusArena["PlayerDefense"]) slot.AllowDrop = x;

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
            List<Card> deckBot = net.GameClient.getDeckBotGame();

            game.SetBotDeck(CreateCardsPanel(deckBot));

        }

        private ToolTip cardToolTip = new ToolTip();

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
                    BackgroundImageLayout = ImageLayout.Zoom,
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

                pic.MouseHover += (s, e) =>
                {
                    if (pic.Tag is Card c)
                    {
                        cardToolTip.SetToolTip(pic,
                            $"Life: {c.Life}\n" +
                            $"Damage: {c.Damage}\n" +
                            $"Shield: {c.Shield}\n" +
                            $"Move: {c.Move}");
                    }
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

            if (slot.Controls.Count > 0) return;

            Panel cardPanel = (Panel)e.Data.GetData(typeof(Panel));
            PictureBox pic = cardPanel.Controls.OfType<PictureBox>().FirstOrDefault();

            slot.Tag = pic.Tag;


            if (cardPanel.Parent is FlowLayoutPanel fp)
            {
                fp.Controls.Remove(cardPanel);
            }

            cardPanel.Dock = DockStyle.Fill;
            slot.Controls.Add(cardPanel);
            game.GenericGlobalMove();

        }

        private void EnemySlot_DragDrop(object sender, DragEventArgs e)
        {

            Panel slot = (Panel)sender;
            Panel enemyCardPanel = slot.Controls.OfType<Panel>().FirstOrDefault();
            PictureBox enemyPic = enemyCardPanel?.Controls.OfType<PictureBox>().FirstOrDefault();

            Panel cardPanel = (Panel)e.Data.GetData(typeof(Panel));
            PictureBox pic = cardPanel.Controls.OfType<PictureBox>().FirstOrDefault();


            Card attacker = pic?.Tag as Card;
            Card defender = enemyPic?.Tag as Card;

            if (attacker == null || attacker.Move <= 0 ||
                cardPanel.Parent is FlowLayoutPanel || defender == null)
                return;


            if (slot.Name.StartsWith("EnemyAtack"))
            {
                foreach (var defense in StatusArena["BotDefense"])
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

            ApplyAttackResult(
                result,
                attacker,
                defender,
                slot,
                true);

            attacker.Move--;
        }

        public void ApplyAttackResult(
            string msg,
            Card attacker,
            Card defender,
            Panel defenderSlot,
            bool isPlayer
            )
        {

            string[] resultSplit = msg.Split(':');

            string act = resultSplit[0];
            int defenderChange = int.Parse(resultSplit[1]);
            int attacketChange = int.Parse(resultSplit[2]);

            switch (act)
            {
                case "SHIELD BREAK":
                    if (defender.Damage <= 0)
                    {
                        defenderSlot.Controls.Clear();
                        break;
                    }

                    var area = isPlayer ? "BotAttack" : "PlayerAttack";

                    foreach (var slot in StatusArena[area])
                    {
                        if (slot.Controls.Count <= 0)
                        {
                            defenderSlot.Controls[0].Dock = DockStyle.Fill;
                            slot.Controls.Add(defenderSlot.Controls[0]);
                            defender.Move--;
                            defenderSlot.Controls.Clear();
                            break;
                        }

                    }

                    defenderSlot.Controls.Clear();
                    break;

                case "SHIELD DAMAGE":
                    defender.Shield = defenderChange;
                    break;

                case "DEFENDER DEAD":
                    defenderSlot.Controls.Clear();
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
            if (game.HaveGlobalMove())
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


        private void BT_EndTurn_Click(object sender, EventArgs e)
        {
            foreach (var item in StatusArena["PlayerAttack"])
            {

                bool BotHaveAnyCard =
                    StatusArena["BotDefense"].Any(p => p.Controls.Count == 1) ||
                    StatusArena["BotAttack"].Any(p => p.Controls.Count == 1);

                
                if (item.Controls.Count == 1 && !BotHaveAnyCard)
                {
                    Card card = GameUtils.GetCardFromSlot(item);

                    if (card.Move == 0) continue;

                    game.DamageBotLife(card.Damage % 8);
                }
               
            }

            game.EndTurn();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
