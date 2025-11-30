using card_game.UI.Shared;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace card_game.Infrastructure.Images
{
    internal class ImageUtils
    {
        public static Image RotateImage(Image img)
        {
            Bitmap bmp = new Bitmap(img.Height, img.Width); // inversão das dimensões

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.TranslateTransform(bmp.Width / 2f, bmp.Height / 2f);
                g.RotateTransform(90);
                g.TranslateTransform(-img.Height / 2f, -img.Width / 2f);

                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(img, new Rectangle(0, 0, img.Height, img.Width));
            }
            FM_Test test = new FM_Test(bmp);
            test.Show();

            return bmp;
        }



    }
}
