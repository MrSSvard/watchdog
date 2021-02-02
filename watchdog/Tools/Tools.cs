using System;


namespace WatchDog.Tools
{
    public static class Tools
    {
        public static DateTime CurrentTime()
        {
            DateTime currentTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Europe/Stockholm");
            return currentTime;
        }
    }
}
