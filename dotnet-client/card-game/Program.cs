using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace card_game
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            Process serverProcess = new Process();
            serverProcess.StartInfo.FileName = "java";
            serverProcess.StartInfo.Arguments = "-jar server.jar";
            serverProcess.StartInfo.CreateNoWindow = true;
            serverProcess.StartInfo.UseShellExecute = false;
            serverProcess.Start();


            ApplicationConfiguration.Initialize();
            Application.Run(new FM_Login());


            if(!serverProcess.HasExited)
                serverProcess.Kill();

        }
    }
}