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

        public static Card? GetCardFromSlot(Panel slot)
        {
            if (slot == null || slot.Controls.Count == 0)
                return null;

            // pega o cardPanel
            var cardPanel = slot.Controls.OfType<Panel>().FirstOrDefault();
            if (cardPanel == null || cardPanel.Controls.Count == 0)
                return null;

            // pega o pictureBox
            var pic = cardPanel.Controls.OfType<PictureBox>().FirstOrDefault();
            if (pic == null)
                return null;

            return pic.Tag as Card;
        }

    }
}
