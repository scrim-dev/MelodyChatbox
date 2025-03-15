using MelodyChatbox.Utils;
using MelodyChatbox.WMC;
using Pastel;

namespace MelodyChatbox
{
    internal class Program
    {
        public const string Version = "1.1";
        public static bool OscRunning { get; set; } = false;

        static void Main()
        {
            Console.CancelKeyPress += OnExit;
            AppDomain.CurrentDomain.ProcessExit += OnProcessExit;

            MStarter:
            ConsLog.SetTitle();
            ConsLog.PrintLogo();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\nHow would you like to display your music?\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" [1] Basic (Artist - track)\n" +
                " [2] Fancy (Artist - track WITH animated seek bar)\n" +
                " [3] Visualized (Artist - track WITH visuals)\n");
            Console.ForegroundColor = ConsoleColor.White;

            try
            {
                ConsLog.SetTitle("Waiting for input...");
                Console.Write(">> ".Pastel(ConsoleColor.Green));
                int option = int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Green;
                switch (option)
                {
                    case 1:
                        OscRunning = true;
                        Console.ForegroundColor = ConsoleColor.White;
                        Chatbox.Start(1);
                        break;
                    case 2:
                        OscRunning = true;
                        Console.ForegroundColor = ConsoleColor.White;
                        Chatbox.Start(2);
                        break;
                    case 3:
                        OscRunning = true;
                        Console.ForegroundColor = ConsoleColor.White;
                        Chatbox.Start(3);
                        break;
                    default:
                        ConsLog.Error("Please select either 1, 2 or 3. Try again.");
                        Thread.Sleep(3400);
                        Console.Clear();
                        goto MStarter;
                }
            }
            catch
            {
                ConsLog.Error("Invalid option. Please try again.");
                Thread.Sleep(3400);
                Console.Clear();
                goto MStarter;
            }
        }

        private static void OnExit(object sender, ConsoleCancelEventArgs e)
        {
            e.Cancel = true;
            Quit();
        }

        private static void OnProcessExit(object sender, EventArgs e)
        {
            Quit();
        }

        private static void Quit()
        {
            if (OscRunning)
            {
                OscRunning = false;
                ConsLog.SetTitle("Goodbye :(");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nGracefully shutting down Melody...");
                WMController.Media_Manager?.Dispose();
                Thread.Sleep(1000);
                Environment.Exit(0);
            }
        }
    }
}
