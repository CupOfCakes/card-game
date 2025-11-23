using card_game.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using net = card_game.Infrastructure.Network;

namespace card_game.Infrastructure.Network
{
    class GameClient
    {
        public static List<Card> getDeckGame(int id)
        {
            try
            {
                using (TcpClient client = new TcpClient("localhost", 5000))
                using (NetworkStream stream = client.GetStream())
                {
                    string message = $"GAMEDECK:{id}";
                    byte[] data = Encoding.UTF8.GetBytes(message + "\n");
                    stream.Write(data, 0, data.Length);

                    string json = net.NetworkUtil.ReadMessage(stream);

                    return Card.DeckFromJson(json);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERRO: {ex.Message}");
                return new List<Card>();
            }
        }

        public static List<Card> getDeckBotGame()
        {
            try
            {
                using (TcpClient client = new TcpClient("localhost", 5000))
                using (NetworkStream stream = client.GetStream())
                {
                    string message = $"BOTDECK";
                    byte[] data = Encoding.UTF8.GetBytes(message + "\n");
                    stream.Write(data, 0, data.Length);

                    string json = net.NetworkUtil.ReadMessage(stream);

                    return Card.DeckFromJson(json);

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
