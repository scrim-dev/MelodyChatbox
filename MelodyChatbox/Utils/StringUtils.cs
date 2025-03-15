﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelodyChatbox.Utils
{
    internal class StringUtils
    {
        public static string Repeat(string text, int count)
        {
            return string.Concat(Enumerable.Repeat(text, count));
        }

        public static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder result = new StringBuilder(length);
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }

            return result.ToString();
        }

        public class StringSeekBar
        {
            private readonly int _barLength;
            private readonly char _filledChar;
            private readonly char _unfilledChar;
            private readonly char[] _cursorSpinChars = { '|', '/', '-', '\\' };
            private int _frameIndex = 0;

            public StringSeekBar(int barLength = 30, char filledChar = '=', char unfilledChar = '-')
            {
                _barLength = barLength;
                _filledChar = filledChar;
                _unfilledChar = unfilledChar;
            }

            public string GenerateSeekBar(TimeSpan currentPosition, TimeSpan totalDuration)
            {
                if (totalDuration.TotalSeconds == 0)
                    return $"[{new string(_unfilledChar, _barLength)}] 00:00 / 00:00";

                double progressRatio = currentPosition.TotalSeconds / totalDuration.TotalSeconds;
                int filledLength = (int)(_barLength * progressRatio);
                filledLength = Math.Clamp(filledLength, 0, _barLength - 1);

                char spinningCursor = _cursorSpinChars[_frameIndex++ % _cursorSpinChars.Length];

                string seekBar = new string(_filledChar, filledLength) + spinningCursor + new string(_unfilledChar, _barLength - filledLength - 1);
                string formattedCurrent = $"{(int)currentPosition.TotalMinutes:D2}:{currentPosition.Seconds:D2}";
                string formattedTotal = $"{(int)totalDuration.TotalMinutes:D2}:{totalDuration.Seconds:D2}";

                return $"[{seekBar}] {formattedCurrent} / {formattedTotal}";
            }
        }
    }
}
