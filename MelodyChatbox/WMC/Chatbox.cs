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

        private static readonly string[] Animation =
        [
            "", "[]", "[-]", "[\\/]", "[---]", "[/--\\]", "[-----]", "[\\------/]", "[/---------\\]", "[\\---------/]", "[/------\\]", "[-----]", "[\\--/]", "[---]", "[/\\]", "[-]", "[]", ""
        ];

        public static void Start(int type)
        {
            switch(type)
            {
                case 1:
                    WMController.Init();
                    while (Program.OscRunning)
                    {
                        WMController.Media_Manager?.ForceUpdate();
                        ConsLog.SetTitle($"Blasting {MediaInfo.Artist}");
                        OscChatbox.SendMessage($"{MediaInfo.Artist} - {MediaInfo.Track}", true, false);

                        Console.WriteLine($"CB: {MediaInfo.Artist} - {MediaInfo.Track}");
                        Thread.Sleep(Speed);
                    }
                    break;
                case 2:
                    WMController.Init();
                    while (Program.OscRunning)
                    {
                        StringUtils.StringSeekBar SB = new();
                        WMController.Media_Manager?.ForceUpdate();
                        ConsLog.SetTitle($"Blasting {MediaInfo.Artist}");
                        OscChatbox.SendMessage($"{MediaInfo.Artist} - {MediaInfo.Track}\n" +
                            $"{SB.GenerateSeekBar(MediaInfo.CurTime, MediaInfo.TOTALTIME)}", true, false);

                        Console.WriteLine($"CB: {MediaInfo.Artist} - {MediaInfo.Track}\n" +
                            $"{SB.GenerateSeekBar(MediaInfo.CurTime, MediaInfo.TOTALTIME)}");
                        Thread.Sleep(Speed);
                    }
                    break;
                case 3:
                    WMController.Init();
                    while (Program.OscRunning)
                    {
                        if (AnimFrame > Animation.Length) { AnimFrame = 0; }
                        AnimFrame++;

                        WMController.Media_Manager?.ForceUpdate();
                        ConsLog.SetTitle($"Blasting {MediaInfo.Artist}");
                        OscChatbox.SendMessage($"{Animation[AnimFrame]}\n{MediaInfo.Artist} - {MediaInfo.Track}\n{Animation[AnimFrame]}", true, false);

                        Console.WriteLine($"{Animation[AnimFrame]}\n{MediaInfo.Artist} - {MediaInfo.Track}\n{Animation[AnimFrame]}");
                        Thread.Sleep(Speed);
                    }
                    break;
                default:
                    throw new ArgumentNullException();
            }
        }
    }
}