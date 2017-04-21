using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.KPI
{
    public class Session
    {
        public Session()
        {

        }

        public string GetSessionTime(PlayerData player)
        {
            int hour = Convert.ToInt32(player.GetEventData(player.GetEventCount() - 1).Hour) - Convert.ToInt32(player.GetEventData(0).Hour);
            int minute = Convert.ToInt32(player.GetEventData(player.GetEventCount() - 1).Minute) - Convert.ToInt32(player.GetEventData(0).Minute);
            int second = Convert.ToInt32(player.GetEventData(player.GetEventCount() - 1).Second) - Convert.ToInt32(player.GetEventData(0).Second);

            string finalTime = "";

            if (second < 0 && minute >= 0)
            {
                minute--;
                second = 60 - second * -1;
            }

            finalTime = hour + ":" + minute + ":" + second;
            return finalTime;
        }

        public int GetSessionTimeInt(PlayerData player)
        {
            int hour = Convert.ToInt32(player.GetEventData(player.GetEventCount() - 1).Hour) - Convert.ToInt32(player.GetEventData(0).Hour);
            int minute = Convert.ToInt32(player.GetEventData(player.GetEventCount() - 1).Minute) - Convert.ToInt32(player.GetEventData(0).Minute);
            int second = Convert.ToInt32(player.GetEventData(player.GetEventCount() - 1).Second) - Convert.ToInt32(player.GetEventData(0).Second);

            int finalTime = 0;

            if (second < 0 && minute >= 0)
            {
                minute--;
                second = 60 - Math.Abs(second);
            }

            finalTime = hour * 3600 + minute * 60 + second;
            return finalTime;
        }

        public string GetAvgSessionTime(List<PlayerData> players, TIME timeFormat)
        {
            float avgSessionTime = 0;
            int playerCountFilter = 0;

            foreach (PlayerData player in players)
            {
                avgSessionTime += GetSessionTimeInt(player);
                if (GetSessionTimeInt(player) > 5)
                    playerCountFilter++;
            }

            avgSessionTime /= playerCountFilter;

            switch (timeFormat)
            {
                case TIME.SECONDS:
                    return avgSessionTime + "";
                case TIME.MINUTES:
                    return avgSessionTime / 60 + "";
                case TIME.HOURS:
                    return avgSessionTime / 3600 + "";
            }

            return "";
        }
    }
}
