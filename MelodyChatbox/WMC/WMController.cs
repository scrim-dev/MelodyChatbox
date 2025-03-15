using MelodyChatbox.Utils;
using Pastel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Control;
using WindowsMediaController;
using static System.Collections.Specialized.BitVector32;
using static WindowsMediaController.MediaManager;

namespace MelodyChatbox.WMC
{
    internal class WMController
    {
        public static MediaManager? Media_Manager { get; set; }

        public static void Init()
        {
            Media_Manager = new MediaManager();

            Media_Manager.OnAnySessionOpened += OnAnySessionOpened;
            Media_Manager.OnAnySessionClosed += OnAnySessionClosed;
            Media_Manager.OnFocusedSessionChanged += OnFocusedSessionChanged;
            Media_Manager.OnAnyMediaPropertyChanged += OnAnyMediaPropertyChanged;
            Media_Manager.OnAnyPlaybackStateChanged += OnAnyPlaybackStateChanged;
            Media_Manager.OnAnyTimelinePropertyChanged += OnAnyTimelinePropertyChanged;

            Media_Manager.Start();
        }

        private static void OnAnySessionOpened(MediaSession session)
        {
            ConsLog.LogWMC($"Session Opened: {session.Id}".Pastel(ConsoleColor.Green));
        }

        private static void OnAnySessionClosed(MediaSession session)
        {
            ConsLog.LogWMC($"Session Closed: {session.Id}".Pastel(ConsoleColor.Red));
        }

        private static void OnFocusedSessionChanged(MediaSession session) { }

        private static void OnAnyMediaPropertyChanged(MediaSession sender, GlobalSystemMediaTransportControlsSessionMediaProperties args)
        {
            ConsLog.LogWMC($"{sender.Id}, PROP: {args.Artist} - {args.Title}");
            MediaInfo.Artist = args.Artist;
            MediaInfo.Track = args.Title;
        }

        private static void OnAnyPlaybackStateChanged(MediaSession sender, GlobalSystemMediaTransportControlsSessionPlaybackInfo args)
        {
            ConsLog.LogWMC($"{sender.Id}, STATUS: {args.PlaybackStatus}");
        }

        private static void OnAnyTimelinePropertyChanged(MediaSession mediaSession, GlobalSystemMediaTransportControlsSessionTimelineProperties timelineProperties)
        {
            ConsLog.LogWMC($"{mediaSession.Id}, TL: {timelineProperties.StartTime}/{timelineProperties.EndTime}");
            MediaInfo.StartTime = timelineProperties.StartTime;
            MediaInfo.EndTime = timelineProperties.EndTime;
            MediaInfo.CurTime = timelineProperties.Position;
            MediaInfo.TOTALTIME = timelineProperties.MaxSeekTime;
        }
    }
}