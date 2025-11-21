using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace card_game.Infrastructure.Network
{
    class LoginClient
    {
        public static string SendLogin(string username, string password)
        {
            try
            {
                
                using (TcpClient client = new TcpClient("localhost", 5000))
                using (NetworkStream stream = client.GetStream())
                {
                    string message = $"LOGIN:{username};{password}";
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
                return $"ERROR:{ex.Message}";
            }
        }

        public static string NewLogin(string username, string password)
        {
            try
            {
                using (TcpClient client = new TcpClient("localhost", 5000))
                using (NetworkStream stream = client.GetStream())
                {
                    string message = $"NEWLOGIN:{username};{password}";
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
                return $"ERROR:{ex.Message}";
            }

        }

        public static string ChangeLogin(string username, string password) 
        {
            try
            {
                using (TcpClient client = new TcpClient("localhost", 5000))
                using (NetworkStream stream = client.GetStream())
                {
                    string message = $"CHANGELOGIN:{username};{password}";
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
                return $"ERROR:{ex.Message}";
            }

        }


    }
}
