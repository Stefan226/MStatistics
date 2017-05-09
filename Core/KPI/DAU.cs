using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.KPI
{
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

        public int GetActiveUsers(MONTHS month, string pathBegin, string pathEnd, int dayIndex = 0)
        {
            string finalPath = "Analytics/" + "2017-" + "0" + (int)month + "-" + pathBegin;

            int finalNumb;

            int begin = Convert.ToInt32(pathBegin);
            int end = Convert.ToInt32(pathEnd);

            string[] days = new string[(end - begin) + 1];

            if (dayIndex == 0)
                dayIndex = days.Length - 2;

            for (int i = days.Length - 1; i >= 0; i--)
            {
                if (begin < 10)
                    days[i] = "0" + (end - i) + "";
                else
                    days[i] = (end - i) + "";
            }

            finalNumb = Directory.GetFiles(finalPath).Length;

            if (pathBegin != pathEnd)
            {
                finalNumb += GetActiveUsers(month, days[dayIndex], pathEnd, --dayIndex);
            }

            return finalNumb;
        }

        public int GetActiveUsersAVG(MONTHS month, string pathBegin, string pathEnd, int dayIndex = 0)
        {
            int sum = GetActiveUsers(month, pathBegin, pathEnd, dayIndex);
            return sum / 7;
        }

        public int GetActiveUsers(MONTHS monthBegin, MONTHS monthEnd, string pathBegin, string pathEnd)
        {
            throw new NotImplementedException();
        }

        int GetDaysInMonth(MONTHS month)
        {

            if ((int)month % 2 == 0)
                return 30;
            else
            {
                if (month == MONTHS.FEBRUARY)
                    return 29;
                else
                    return 31;
            }
        }
    }
}
