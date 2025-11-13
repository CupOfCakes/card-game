using card_game.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace card_game
{
    class DeckCode
    {
        public static List<Card> getDeck(int id)
        {
            try
            {
                using (TcpClient client = new TcpClient("localhost", 5000))
                using (NetworkStream stream = client.GetStream())
                {
                    string message = $"DECK:{id}";
                    byte[] data = Encoding.UTF8.GetBytes(message + "\n");
                    stream.Write(data, 0, data.Length);

                    using (var ms = new MemoryStream())
                    {
                        byte[] buffer = new byte[8192];
                        int bytesRead;

                        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0) 
                        {
                            ms.Write(buffer, 0, bytesRead);
                            if (!stream.DataAvailable) break;
                        }

                        string json = Encoding.UTF8.GetString(ms.ToArray()).Trim();

                        var deck = Card.FromJson(json);
                        return deck;
                    }

                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERRO: {ex.Message}");
                return new List<Card>();
            }

        }

    }
}
