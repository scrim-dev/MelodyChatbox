using Pastel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelodyChatbox.Utils
{
    internal class ConsLog
    {
        public static void Log(string message)
        {
            Console.Write("[".Pastel("#e6e6e6"));
            Console.Write("MELODYCB".Pastel("#0080ff"));
            Console.Write("] ".Pastel("#e6e6e6"));
            Console.Write($"{message}\n".Pastel("#ffffff"));
        }

        public static void LogWMC(string message)
        {
            Console.Write("[".Pastel("#e6e6e6"));
            Console.Write("MELODYCB".Pastel("#0080ff"));
            Console.Write("] ".Pastel("#e6e6e6"));

            Console.Write("[".Pastel("#e6e6e6"));
            Console.Write("WMC".Pastel("#b947ff"));
            Console.Write("] ".Pastel("#e6e6e6"));

            Console.Write($"{message}\n".Pastel("#ffffff"));
        }

        public static void Warn(string message)
        {
            Console.Write("[".Pastel("#e6e6e6"));
            Console.Write("MELODYCB".Pastel("#0080ff"));
            Console.Write("] ".Pastel("#e6e6e6"));

            Console.Write("[".Pastel("#e6e6e6"));
            Console.Write("WARN".Pastel("#ffdd00"));
            Console.Write("] ".Pastel("#e6e6e6"));

            Console.Write($"{message}\n".Pastel("#ffdd00"));
        }

        public static void Error(string message)
        {
            Console.Write("[".Pastel("#e6e6e6"));
            Console.Write("MELODYCB".Pastel("#0080ff"));
            Console.Write("] ".Pastel("#e6e6e6"));

            Console.Write("[".Pastel("#e6e6e6"));
            Console.Write("ERROR".Pastel("#e00034"));
            Console.Write("] ".Pastel("#e6e6e6"));

            Console.Write($"{message}\n".Pastel("#e00034"));
        }

        public static void SetTitle(string? title = null)
        {
            if (string.IsNullOrEmpty(title))
            {
                Console.Title = $"MelodyChatbox v{Program.Version}";
            }
            else
            {
                Console.Title = $"MelodyChatbox v{Program.Version} - {title}";
            }
        }

        //Could of been done better lol
        public static void PrintLogo()
        {
            Console.WriteLine(@" /$$      /$$ /$$$$$$$$ /$$        /$$$$$$  /$$$$$$$  /$$     /$$".Pastel("#0080ff"));
            Console.WriteLine(@"| $$$    /$$$| $$_____/| $$       /$$__  $$| $$__  $$|  $$   /$$/".Pastel("#0080ff"));
            Console.WriteLine(@"| $$$$  /$$$$| $$      | $$      | $$  \ $$| $$  \ $$ \  $$ /$$/ ".Pastel("#0080ff"));
            Console.WriteLine(@"| $$ $$/$$ $$| $$$$$   | $$      | $$  | $$| $$  | $$  \  $$$$/  ".Pastel("#0080ff"));
            Console.WriteLine(@"| $$  $$$| $$| $$__/   | $$      | $$  | $$| $$  | $$   \  $$/   ".Pastel("#003acc"));
            Console.WriteLine(@"| $$\  $ | $$| $$      | $$      | $$  | $$| $$  | $$    | $$    ".Pastel("#003acc"));
            Console.WriteLine(@"| $$ \/  | $$| $$$$$$$$| $$$$$$$$|  $$$$$$/| $$$$$$$/    | $$    ".Pastel("#003acc"));
            Console.WriteLine(@"|__/     |__/|________/|________/ \______/ |_______/     |__/    ".Pastel("#003acc"));
        }
    }
}