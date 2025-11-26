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
            GlobalMoves += 2;
        }

        private void BotTurn(Dictionary<String, List<Panel>> statusArena)
        {
            // bot choices
            // if 5 <= cards on hand => buy 1 card
            // if just 1 card on hand buy 2 cards
            // if have a card with shield >= 80 put on defense
            // if have a card with damage >= 80 put on atack
            // for card atack on arena atack

            //buy
            if (BotHand.Count == 1)
            {
                BotBuyCard();
                BotBuyCard();
            }

            if (BotHand.Count <= 5) BotBuyCard();

            //forced put

            foreach (var item in BotHand) 
            {
                PictureBox pic = item.Controls.OfType<PictureBox>().FirstOrDefault();
                Card card = pic?.Tag as Card;

                if(card.Shield >= 80)
                {
                    foreach(var i in statusArena.Keys)
                    {
                    }
                }

            }




        }

        private void BotBuyCard()
        {
            BotHand.Add(BotDeck[0]);
            BotDeck.Add(BotDeck[0]);
            BotDeck.RemoveAt(0);
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
