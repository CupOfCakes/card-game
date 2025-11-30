using card_game.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using net = card_game.Infrastructure.Network;


namespace card_game.Infrastructure.GameManegers
{
    public class GameController
    {
        private Turns.TurnManager turnManager;

        public event Action OnPlayerTurn;
        public event Action OnBotTurn;
        public event EventHandler<BotAttackEventArgs> OnBotAttackUI;

        private int GlobalMoves = 2;
        private int life = 20;

        private List<Panel> BotHand { get; set; }
        private List<Panel> BotDeck { get; set; }

        Dictionary<String, List<Panel>> statusArena;

        public Func<Dictionary<String, List<Panel>>> OnGetStatusArena;
        public Action<Dictionary<String, List<Panel>>> OnSetStatusArena;

        public event EventHandler<ChangeLB_GMEventArgs> OnLB_GM;

        private int playerLife;
        private int botLife;

        public event Action OnGB_Life;

        public event EventHandler<EndGameEventArgs> OnEndGame;

        public GameController() 
        { 
            turnManager = new Turns.TurnManager();
            playerLife = life;
            botLife = life;
        }

        public class BotAttackEventArgs : EventArgs
        {
            public string Result { get; set; }
            public Card Attacker { get; set; }
            public Card Defender { get; set; }
            public Panel Slot { get; set; }
            public bool isPLayer { get; set; }
        }

        public class ChangeLB_GMEventArgs : EventArgs
        {
            public int gm {  get; set; }
        }

        public class EndGameEventArgs : EventArgs
        {
            public string winner { get; set; }
        }

        public int GetBotLife()
        {
            return botLife;
        }

        private void CheckWin()
        {
            if (playerLife <= 0) OnEndGame?.Invoke(this, new EndGameEventArgs
            {
                winner = "Bot"
            });
            else if (botLife <= 0) OnEndGame?.Invoke(this, new EndGameEventArgs
            {
                winner = "Player"
            });
        }

        public void EndGame(string winner)
        {
            MessageBox.Show($"{winner} Win!!!");
        }

        public int GetPlayerLife()
        {
            return playerLife;
        }


        public int GetGM()
        {
            return GlobalMoves;
        }

        public void DamageBotLife(int damage)
        {
            botLife -= damage;
        }


        public void StartGame()
        {
            HandleTurn();
        }

        private void HandleTurn()
        {
            CheckWin();
            GlobalMoves = 2;
            if (turnManager.Phase == Turns.TurnPhase.Player)
            {
                OnPlayerTurn?.Invoke();
                OnLB_GM?.Invoke(this, new ChangeLB_GMEventArgs
                {
                    gm = GlobalMoves
                });
                OnGB_Life?.Invoke();

            }
            else
            {
                statusArena = OnGetStatusArena?.Invoke();
                statusArena = BotTurn(statusArena);
                OnSetStatusArena?.Invoke(statusArena);
                OnBotTurn?.Invoke();
                OnGB_Life?.Invoke();
                EndTurn();
            }
        }

        public void SetStatusArena(Dictionary<String, List<Panel>> Arena)
        {
            statusArena = Arena;
        }

        public Dictionary<String, List<Panel>> GetStatusArena()
        {
            return statusArena;
        }

        public void GenericGlobalMove()
        {
            GlobalMoves--;

            OnLB_GM?.Invoke(this, new ChangeLB_GMEventArgs
            {
                gm = GlobalMoves
            });

        }

        public bool HaveGlobalMove()
        {
            if (GlobalMoves > 0) return true;
            else return false;
        }

        public void SetBotDeck(List<Panel> deck)
        {
            BotDeck = deck;
            BotHand = BotDeck.Take(3).ToList();

        }

        public void EndTurn()
        {
            turnManager.NextPhase();
            HandleTurn();
        }

        public string ProcessAttack(Card attacker, Card defender, bool isDefense)
        {
            if (isDefense)
            {
                defender.Shield -= attacker.Damage;

                if (defender.Shield <= 0)
                {
                    if (defender.Damage > 0) return "SHIELD BREAK:0:0";
                    else return "DEFENDER DEAD:0:0";
                }

                return $"SHIELD DAMAGE:{defender.Shield}:0";
            }
            else
            {
                defender.Life -= attacker.Damage;

                if (defender.Life <= 0) return "DEFENDER DEAD:0:0";
                else
                {
                    if (attacker.Shield > 0)
                    {
                        attacker.Shield -= (defender.Damage / 5);
                        return $"REVENGE ON SHIELD:{defender.Life}:{attacker.Shield}";
                    }
                    else
                    {
                        attacker.Life -= (defender.Damage / 5);
                        return $"REVENGE ON LIFE:{defender.Life}:{attacker.Life}";
                    }
                }
            }
        }

       


        private bool PlayerHasDefense(List<Panel> list)
        {
            return list.Any(p => p.Controls.Count == 1);
        }

        private Dictionary<String, List<Panel>> ExecuteBotAttacks(Dictionary<String, List<Panel>> statusArena)
        {
            foreach (var i in statusArena["BotAttack"])
            {
                if (i.Controls.Count == 0) continue;

                Card atack = GameUtils.GetCardFromSlot(i);
                atack.Move = Math.Min(atack.Move + 1, 1);

                bool playerHaveAnyCard =
                    statusArena["PlayerDefense"].Any(p => p.Controls.Count == 1) ||
                    statusArena["PlayerAttack"].Any(p => p.Controls.Count == 1);

                if (!playerHaveAnyCard)
                {
                    playerLife -= atack.Damage % 8;
                }

                if (PlayerHasDefense(statusArena["PlayerDefense"]))
                {
                    foreach (var enemyDefense in statusArena["PlayerDefense"])
                    {
                        if (enemyDefense.Controls.Count == 1)
                        {
                            Card defense = GameUtils.GetCardFromSlot(enemyDefense);
                            string result = ProcessAttack(atack, defense, true);
                            OnBotAttackUI?.Invoke(this, new BotAttackEventArgs
                            {
                                Result = result,
                                Attacker = atack,
                                Defender = defense,
                                Slot = enemyDefense,
                                isPLayer = false
                            });
                            break;
                        }
                    }

                    continue;
                }

                foreach (var enemyAtack in statusArena["PlayerAttack"])
                {
                    if (enemyAtack.Controls.Count == 1)
                    {
                        Card defense = GameUtils.GetCardFromSlot(enemyAtack);
                        string result = ProcessAttack(atack, defense, false);
                        OnBotAttackUI?.Invoke(this, new BotAttackEventArgs
                        {
                            Result = result,
                            Attacker = atack,
                            Defender = defense,
                            Slot = enemyAtack,
                            isPLayer = false
                        });
                        break;
                    }
                }

            }

            return statusArena;
        }

        private void ExecuteBotBuy()
        {
            if (BotHand.Count <= 1)
            {
                BotBuyCard();
                BotBuyCard();
            }
            else if (BotHand.Count <= 5) BotBuyCard();

        }

        private Dictionary<String, List<Panel>> PutAttackCards(Dictionary<String, List<Panel>> statusArena)
        {
            for (int i = BotHand.Count - 1; i >= 0; i--)
            {
                var item = BotHand[i];
                Card card = GameUtils.GetCardFromPanel(item);

                if (card.Damage >= 80)
                {
                    foreach (var attack in statusArena["BotAttack"])
                    {
                        if (attack.Controls.Count == 0)
                        {
                            item.Dock = DockStyle.Fill;
                            attack.Controls.Add(item);
                            BotHand.Remove(item);
                            GenericGlobalMove();
                            break;
                        }
                    }
                }

            }
            return statusArena;
        }

        private Dictionary<String, List<Panel>> PutDefenseCards(Dictionary<String, List<Panel>> statusArena)
        {
            for (int i = BotHand.Count - 1; i >= 0; i--)
            {
                var item = BotHand[i];
                Card card = GameUtils.GetCardFromPanel(item);

                if (card.Shield >= 80)
                {
                    foreach (var defense in statusArena["BotDefense"])
                    {
                        if (defense.Controls.Count == 0)
                        {
                            item.Dock = DockStyle.Fill;
                            defense.Controls.Add(item);
                            BotHand.RemoveAt(i);
                            GenericGlobalMove();
                            break;
                        }
                    }
                }  

            }
            return statusArena;
        }

        private Dictionary<String, List<Panel>> RemainGMBot(Dictionary<String, List<Panel>> statusArena)
        {
            for (int i = 0; i < GlobalMoves; i++)
            {
                if (BotHand.Count == 0) break;

                Panel bestPanel = null;

                Card bestCard = null;

                bool defenseFull = statusArena["BotDefense"].All(s => s.Controls.Count > 1);
                bool attackFull = statusArena["BotAttack"].All(s => s.Controls.Count > 0);

                foreach (var item in BotHand)
                {

                    Card card = GameUtils.GetCardFromPanel(item);

                    if (bestCard == null)
                    {
                        bestCard = card;
                        bestPanel = item;
                        continue;
                    }


                    if (card.Shield > bestCard.Damage && defenseFull) continue;
                    else if (card.Damage > bestCard.Shield && attackFull) continue;


                    if (card.Damage > bestCard.Damage || card.Shield > bestCard.Shield)
                    {
                        bestCard = card;
                        bestPanel = item;
                    }

                }

                if (bestCard.Shield > bestCard.Damage && bestCard.Damage > 0)
                {
                    foreach (var slot in statusArena["BotDefense"])
                    {
                        if (slot.Controls.Count == 0)
                        {
                            slot.Controls.Add(bestPanel);
                            BotHand.Remove(bestPanel);
                            break;
                        }

                    }
                }
                else if (bestCard.Damage > bestCard.Shield && bestCard.Shield > 0)
                {
                    foreach (var j in statusArena["BotAttack"])
                    {
                        if (j.Controls.Count == 0)
                        {
                            j.Controls.Add(bestPanel);
                            BotHand.Remove(bestPanel);
                            break;
                        }
                    }
                }
            }

            return statusArena;
        }

        /// <summary>
        /// Execute Bot Turn
        /// if 5 <= cards on hand => buy 1 card
        /// if just 1 or minus card on hand buy 2 cards
        /// if have a card with shield >= 80 put on defense
        /// if have a card with damage >= 80 put on atack
        /// for card atack on arena atack
        /// </summary>
        /// <param name="statusArena">Current state of the game arena.</param>
        /// <returns>The updated state of the arena after the bot's turn.</returns>
        private Dictionary<String, List<Panel>> BotTurn(Dictionary<String, List<Panel>> statusArena)
        {
            
            GlobalMoves = 2;

            statusArena = ExecuteBotAttacks(statusArena);

            //buy
            ExecuteBotBuy();
            if (!HaveGlobalMove()) return statusArena;

            //forced put card on arena
            statusArena = PutAttackCards(statusArena);
            if (!HaveGlobalMove()) return statusArena;

            statusArena = PutDefenseCards(statusArena);
            if (!HaveGlobalMove()) return statusArena;

            //if remain some GM 
            statusArena = RemainGMBot(statusArena);
            return statusArena;
            
        }

        private void BotBuyCard()
        {
            BotHand.Add(BotDeck[0]);
            BotDeck.Add(BotDeck[0]);
            BotDeck.RemoveAt(0);
            GenericGlobalMove();
        }

    }
}
