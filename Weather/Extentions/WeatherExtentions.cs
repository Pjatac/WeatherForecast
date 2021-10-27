using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Weather.Extentions
{
    public static class WeatherExtensions
    {
        public static IEnumerable<int> GetCoordsIndexes(this string source, string matchString)
        {
            matchString = Regex.Escape(matchString);
            foreach (Match match in Regex.Matches(source, matchString))
            {
                yield return match.Index;
            }
        }
        public static DateTime UnixTimeStampToDateTime(this int unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }
    }
}
