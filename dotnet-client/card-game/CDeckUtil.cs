using card_game.Model;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace card_game
{
    internal class CDeckUtil
    {
        public static string sendCard(Card card)
        {
            try
            {
                string base64Image = EncodeImage(card.BaseImage);

                var cardData = new
                {
                    card.UserId,
                    card.CardName,
                    card.Life,
                    card.Damage,
                    card.Shield,
                    card.Type,
                    ImageBase64 = base64Image
                };

                string json = JsonSerializer.Serialize(cardData);

                string message = $"NEWCARD:{json}";

                using (TcpClient client = new TcpClient("localhost", 5000))
                using (NetworkStream stream = client.GetStream())
                {

                    byte[] data = Encoding.UTF8.GetBytes(message + "\n");
                    stream.Write(data, 0, data.Length);

                    byte[] responseData = new byte[250];
                    int bytes = stream.Read(responseData, 0, responseData.Length);
                    string response = Encoding.UTF8.GetString(responseData, 0, bytes);

                    return response.Trim();
                }
            }
            catch (Exception ex)
            {
                return $"ERRO: {ex}";
            }
        }

        public static string EncodeImage(Image image)
        {
            if (image == null) return null;

            using (var ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Png);
                return Convert.ToBase64String(ms.ToArray());
            }
        }
    }
}
