using card_game.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace card_game.Infrastructure.GameManegers
{
    internal class GameUtils
    {
        public static Card? GetCardFromPanel(Panel panel)
        {
            return panel.Controls
                .OfType<PictureBox>()
                .FirstOrDefault()?
                .Tag as Card;
        }

    }
}
