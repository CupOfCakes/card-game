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

                    string json = ReadMessage(stream);

                    return Card.FromJson(json);

                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERRO: {ex.Message}");
                return new List<Card>();
            }

        }

        public static List<Card> getOffDeckCards(int id)
        {
            try
            {
                using (TcpClient client = new TcpClient("localhost", 5000))
                using (NetworkStream stream = client.GetStream())
                {
                    string message = $"OFFDECKCARDS:{id}";
                    byte[] data = Encoding.UTF8.GetBytes(message + "\n");
                    stream.Write(data, 0, data.Length);

                    string json = ReadMessage(stream);

                    return Card.FromJson(json);


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERRO: {ex.Message}");
                return new List<Card>();
            }

        }

        private static string ReadMessage(NetworkStream stream)
        {
            byte[] buffer = new byte[4096];
            using (var ms = new MemoryStream())
            {
                while (true)
                {
                    int read = stream.Read(buffer, 0, buffer.Length);
                    if (read <= 0) break;

                    ms.Write(buffer, 0, read);

                    string text = Encoding.UTF8.GetString(ms.ToArray());
                    if (text.Contains("---END---"))
                    {
                        return text.Replace("---END---", "").Trim();
                    }
                }
            }

            throw new Exception("Mensagem não terminou corretamente.");
        }

    }
}
