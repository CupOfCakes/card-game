using card_game.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace card_game.Infrastructure.GameManegers
{
    public class GameController
    {
        private Turns.TurnManager turnManager;

        private event Action OnPlayerTurn;
        private event Action OnBotTurn;

        private int GlobalMoves = 2;

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

        private void PlayerTurn()
        {

        }

        private void BotTurn()
        {

        }

        public void EndTurn()
        {
            turnManager.NextPhase();
            HandleTurn();
        }


    }
}
