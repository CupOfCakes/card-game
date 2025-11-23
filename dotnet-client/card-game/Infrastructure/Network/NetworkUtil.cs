using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace card_game.Infrastructure.Network
{
    internal class NetworkUtil
    {
        public static string ReadMessage(NetworkStream stream)
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
