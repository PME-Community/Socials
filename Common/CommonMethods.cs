using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Socials.Common
{
	public static class CommonMethods
	{
		public static DateTime Today()
		{
			return DateTime.Today;
		}

        public static int CurrentDayOfWeek()
        {
			var today = Today();
            return (int)today.DayOfWeek;
        }

        public static DateTime FirstDayOfWeek()
        {
            var today = Today();
            return today.AddDays(-CurrentDayOfWeek());
        }

        public static DateTime LastDayOfWeek()
        {
            return FirstDayOfWeek().AddDays(6);
        }

        public static DateTime FirstDayOfMonth()
        {
            var today = Today();
            return new DateTime(today.Year, today.Month, 1);
        }

        public static DateTime LastDayOfMonth()
        {
            return FirstDayOfMonth().AddMonths(1).AddDays(-1);
        }

        public static int DaysUntilNextBiWeekly()
        {
            var today = Today();
            return 14 - (today - FirstDayOfWeek()).Days;
        }

        public static DateTime NextBiWeekly()
        {
            var today = Today();
            return today.AddDays(DaysUntilNextBiWeekly());
        }

        public static DateTime BiWeeklyStart()
        {
            return NextBiWeekly();
        }

        public static DateTime BiWeeklyEnd()
        {
            return NextBiWeekly().AddDays(13);
        }

        public static List<T> GetRandomElements<T>(this List<T> list, int elementsCount)
        {
            return list.OrderBy(arg => Guid.NewGuid()).Take(elementsCount).ToList();
        }

        public static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$()";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
