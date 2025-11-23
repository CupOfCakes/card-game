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

        private void BotTurn()
        {

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

                if (defender.Shield <= 0) return "SHIELD BREAK:0:0";

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
