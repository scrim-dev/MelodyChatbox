using BuildSoft.VRChat.Osc.Chatbox;
using MelodyChatbox.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelodyChatbox.WMC
{
    internal class Chatbox
    {
        public static int Speed { get; set; } = 1500;
        public static int AnimFrame { get; private set; } = 0;

        private static readonly string[] BorderThingys =
        [
            "[/]","[-]","[\\]","[/]","[-]","[\\]","[/]","[-]","[\\]","[/]","[-]","[\\]","[/]","[-]","[\\]","[/]","[-]","[\\]","[/]","[-]","[\\]","[/]","[-]","[\\]","[/]","[-]","[\\]"
        ];

        public static void Start(int type)
        {
            WMController.Media_Manager?.ForceUpdate();
            ConsLog.Warn("Forcefully updating WMC Manager.");
            Thread.Sleep(1300);
            switch (type)
            {
                case 1:
                    WMController.Init();
                    while (Program.OscRunning)
                    {
                        if (!MediaInfo.IsPaused)
                        {
                            ConsLog.SetTitle($"Blasting {MediaInfo.Artist}");
                            OscChatbox.SendMessage($"{MediaInfo.Artist} - {MediaInfo.Track}", true, false);

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("CHATBOX PREVIEW");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"{MediaInfo.Artist} - {MediaInfo.Track}");
                        }
                        else
                        {
                            ConsLog.SetTitle("PAUSED!");
                            OscChatbox.SendMessage("[Paused]", true, false);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Session Paused!");
                        }
                        Thread.Sleep(Speed);
                    }
                    break;
                case 2:
                    WMController.Init();
                    while (Program.OscRunning)
                    {
                        if (!MediaInfo.IsPaused)
                        {
                            StringUtils.StringSeekBar SB = new();
                            
                            ConsLog.SetTitle($"Blasting {MediaInfo.Artist}");
                            OscChatbox.SendMessage($"{MediaInfo.Artist} - {MediaInfo.Track}\n" +
                                $"{SB.GenerateSeekBar(MediaInfo.CurTime, MediaInfo.TOTALTIME)}", true, false);

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("CHATBOX PREVIEW");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"{MediaInfo.Artist} - {MediaInfo.Track}\n" +
                                $"{SB.GenerateSeekBar(MediaInfo.CurTime, MediaInfo.TOTALTIME)}");
                            MediaInfo.CurTime = MediaInfo.CurTime.Add(TimeSpan.FromMilliseconds(Speed)); //This is probably not accurate but it works
                        }
                        else
                        {
                            ConsLog.SetTitle("PAUSED!");
                            OscChatbox.SendMessage("[Paused]", true, false);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Session Paused!");
                        }
                        Thread.Sleep(Speed);
                    }
                    break;
                case 3:
                    WMController.Init();
                    while (Program.OscRunning)
                    {
                        if (!MediaInfo.IsPaused)
                        {
                            //Placing this in a try catch cuz of some WEIRD error I can't get rid of
                            try
                            {
                                if (AnimFrame > BorderThingys.Length) { AnimFrame = 0; }
                                AnimFrame++;

                                ConsLog.SetTitle($"Blasting {MediaInfo.Artist}");
                                OscChatbox.SendMessage($"{BorderThingys[AnimFrame]} {MediaInfo.Artist} - {MediaInfo.Track} {BorderThingys[AnimFrame]}", true, false);

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("CHATBOX PREVIEW");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{BorderThingys[AnimFrame]} {MediaInfo.Artist} - {MediaInfo.Track} {BorderThingys[AnimFrame]}");
                            }
                            catch { }
                        }
                        else
                        {
                            ConsLog.SetTitle("PAUSED!");
                            OscChatbox.SendMessage("[Paused]", true, false);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Session Paused!");
                        }
                        Thread.Sleep(Speed);
                    }
                    break;
                default:
                    throw new ArgumentNullException();
            }
        }
    }
}