using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace card_game.Domain.Entities
{
    internal class Player
    {
        public string Name { get; set; }
        public List<Card> Deck { get; set; }
        public int Life { get; set; }
        public int GlobalMoves { get; set; }

    }
}
