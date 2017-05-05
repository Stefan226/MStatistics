using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.KPI
{
    public enum MONTHS
    {
        JANUARY = 01,
        FEBRUARY = 02,
        MARCH = 03,
        APRIL = 04,
        MAY = 05,
        JUNE = 06,
        JULY = 07,
        AUGUST = 08,
        SEPTEMBER = 09,
        OKTOBER = 10,
        NOVEMBER = 11,
        DECEMBER = 12
    }




    public class DAU
    {
        public DAU()
        {

        }

        public string GetDailyActiveUsers(string path)
        {
            string finalPath = "Analytics/" + path;

            if (Directory.Exists(finalPath) && path != "")
                return Directory.GetFiles(finalPath).Length + "";
            return "";
        }

        public int GetDailyActiveUsersInt(string path)
        {
            string finalPath = "Analytics/" + path;

            if (Directory.Exists(finalPath) && path != "")
                return Directory.GetFiles(finalPath).Length;
            return -1;
        }

        public string GetWeeklyActiveUsers(MONTHS month, string pathBegin, string pathEnd, int dayIndex = 5)
        {
            string finalPath = "Analytics/" + "2016-" + (int)month + "-" + pathBegin;

            int finalNumb = 0;

            string[] days = new string[7];

            int begin = Convert.ToInt32(pathBegin);
            int end = Convert.ToInt32(pathEnd);

            for (int i = days.Length - 1; i >= 0; i--)
            {
                if (begin < 10)
                    days[i] = "0" + (end - i) + "";
                else
                    days[i] = (end - i) + "";
            }

            Console.WriteLine("eeee");

            if (Directory.Exists(finalPath))
                finalNumb += Directory.GetFiles(finalPath).Length;

            if (pathBegin != pathEnd)
            {
                return GetWeeklyActiveUsers(month, days[dayIndex], pathEnd, --dayIndex);
            }

            return finalNumb + "";
        }
    }
}
