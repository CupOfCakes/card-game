using card_game.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace card_game.Infrastructure.Network
{
    class DeckClient
    {

        public static void saveDeck(List<int> deck, int userId)
        {
            try
            {
                using (TcpClient client = new TcpClient("localhost", 5000))
                using (NetworkStream stream = client.GetStream())
                {
                    string ids = string.Join(",", deck);

                    string message = $"SAVEDECK:{ids}:{userId}";
                    byte[] data = Encoding.UTF8.GetBytes(message + "\n");
                    stream.Write(data, 0, data.Length);

                    byte[] responseData = new byte[250];
                    int bytes = stream.Read(responseData, 0, responseData.Length);
                    string response = Encoding.UTF8.GetString(responseData, 0, bytes);

                    MessageBox.Show(response.Trim());
                }
            }catch(Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.Message);
            }
        }


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

                    return Card.DeckFromJson(json);

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

                    return Card.DeckFromJson(json);


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
                    int endIndex = text.IndexOf("---END---");
                    if (endIndex >= 0)
                    {
                        string json = text.Substring(0, endIndex).Trim();
                        return json;
                    }
                }
            }

            throw new Exception("Mensagem não terminou corretamente.");
        }

    }
}
