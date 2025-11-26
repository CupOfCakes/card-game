using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace card_game.Infrastructure.Network
{
    internal class ConfigClient
    {

        public static string DeleteAccount(int userId)
        {
            try
            {
                using (TcpClient client = new TcpClient("localhost", 5000))
                using (NetworkStream stream = client.GetStream())
                {
                    string msg = $"DELETEACCOUNT:{userId}";
                    byte[] data = Encoding.UTF8.GetBytes(msg + "\n");
                    stream.Write(data, 0, data.Length);

                    byte[] responseData = new byte[250];
                    int bytes = stream.Read(responseData, 0, responseData.Length);
                    string response = Encoding.UTF8.GetString(responseData, 0, bytes);

                    return response;
                }
            }
            catch (Exception ex)
            {
                return $"ERRO: {ex.Message}";
            }

        }
    }

}

