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

        private int GlobalMoves = 2;

        private List<Panel> BotHand { get; set; }
        private List<Panel> BotDeck { get; set; }

        private int PlayerLife {  get; set; }
        private int BotLife { get; set; }

        public GameController() 
        { 
            turnManager = new Turns.TurnManager();
        }

        private void HandleTurn()
        {
            if (turnManager.Phase == Turns.TurnPhase.Player) OnPlayerTurn?.Invoke();
            else OnBotTurn?.Invoke();
        }

        public void GenericGlobalMove()
        {
            GlobalMoves--;
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

        private void PlayerTurn()
        {
            GlobalMoves = 2;
        }

        private bool PlayerHasDefense(List<Panel> list)
        {
            return list.Any(p => p.Controls.Count == 1);
        }

        private Dictionary<String, List<Panel>> BotTurn(Dictionary<String, List<Panel>> statusArena)
        {
            // bot choices
            // if 5 <= cards on hand => buy 1 card
            // if just 1 or minus card on hand buy 2 cards
            // if have a card with shield >= 80 put on defense
            // if have a card with damage >= 80 put on atack
            // for card atack on arena atack

            GlobalMoves = 2;


            foreach(var i in statusArena["BotAttack"])
            {
                if(i.Controls.Count == 0) continue;
                
                Card atack = GameUtils.GetCardFromPanel(i);
                atack.Move = Math.Min(atack.Move + 1, 1);

                if (PlayerHasDefense(statusArena["PlayerDefense"]))
                {
                    foreach (var enemyDefense in statusArena["PlayerDefense"])
                    {
                        if (enemyDefense.Controls.Count == 1)
                        {
                            Card defense = GameUtils.GetCardFromPanel(enemyDefense);
                            ProcessAttack(atack, defense, true);
                            break;
                        }
                    }

                    continue;
                }

                

                foreach (var enemyAtack in statusArena["PlayerAttack"])
                {
                    if (enemyAtack.Controls.Count == 1)
                    {
                        Card defense = GameUtils.GetCardFromPanel(enemyAtack);
                        ProcessAttack(atack, defense, false);
                        break;
                    }
                }
            }


            //buy
            if (BotHand.Count <= 1)
            {
                BotBuyCard();
                BotBuyCard();
                return statusArena;
            }

            if (BotHand.Count <= 5) BotBuyCard();

            //forced put card on arena

            for (int i = BotHand.Count - 1; i >= 0; i--) 
            {
                var item = BotHand[i];
                Card card = GameUtils.GetCardFromPanel(item);

                if (card.Shield >= 80)
                {
                    foreach(var defense in statusArena["BotDefense"])
                    {
                        if (defense.Controls.Count == 0)
                        {
                            defense.Controls.Add(item);
                            BotHand.RemoveAt(i);
                            GenericGlobalMove();
                            break;
                        }
                    }
                }

                if (!HaveGlobalMove()) return statusArena;

                if (card.Damage >= 80)
                {
                    foreach (var attack in statusArena["BotAttack"])
                    {
                        if (attack.Controls.Count == 0)
                        {
                            attack.Controls.Add(item);
                            BotHand.Remove(item);
                            GenericGlobalMove();
                            break;
                        }
                    }
                }

            }

            if(!HaveGlobalMove()) return statusArena;

            
            

            for (int i = 0; i < GlobalMoves; i++) {
                if (BotHand.Count == 0) break;

                Panel bestPanel = null;

                Card bestCard = null;

                foreach (var item in BotHand)
                {
                    Card card = GameUtils.GetCardFromPanel(item);

                    if (card.Damage > bestCard.Damage || card.Shield > bestCard.Shield)
                    {
                        bestCard = card;
                        bestPanel = item;
                    }

                }

                if(bestCard.Shield > bestCard.Damage && bestCard.Damage > 0)
                {
                    foreach(var slot in statusArena["BotDefense"])
                    {
                        if (slot.Controls.Count == 0)
                        {
                            slot.Controls.Add(bestPanel);
                            BotHand.Remove(bestPanel);
                            break;
                        }

                    }
                }
                else if(bestCard.Damage > bestCard.Shield && bestCard.Shield > 0)
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

        private void BotBuyCard()
        {
            BotHand.Add(BotDeck[0]);
            BotDeck.Add(BotDeck[0]);
            BotDeck.RemoveAt(0);
            GenericGlobalMove();
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
                    else { 
                        attacker.Life -= (defender.Damage / 5);
                        return $"REVENGE ON LIFE:{defender.Life}:{attacker.Life}";
                    }
                }
            }
        }


    }
}
