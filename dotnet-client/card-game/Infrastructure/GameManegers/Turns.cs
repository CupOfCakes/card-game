using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace card_game.Infrastructure.GameManegers
{
    internal class Turns
    {
        public enum TurnPhase
        {
            Player,
            Bot
        }

        public class TurnManager
        {
            public TurnPhase Phase { get; private set; } = TurnPhase.Player;
            public int CurrentPlayer { get; private set; } = 0;

            public void NextPhase()
            {
                Phase = Phase switch
                {
                    TurnPhase.Player => TurnPhase.Bot,
                    TurnPhase.Bot => TurnPhase.Player,
                    _ => TurnPhase.Player
                };

                if (Phase == TurnPhase.Player)
                {
                    CurrentPlayer = 1 - CurrentPlayer;
                }

            }


        }
    }
}
