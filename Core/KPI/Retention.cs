using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Core.KPI
{
    public class Retention
    {


        public Retention()
        {
            
        }

        public string GetRetentionDayOne(MONTHS month, string day)
        {
            string finalPath = "Analytics/" + "2017-" + (int)month + "-" + day;

            if ((int)month < 10)
                finalPath = "Analytics/" + "2017-" + "0" + (int)month + "-" + day;

            Data data = new Data();

            int dayBefore = Convert.ToInt32(day) - 1;

            string _dayBefore = dayBefore + "";

            if (dayBefore < 10)
                _dayBefore = "0" + dayBefore;

            List<string> playerIds = data.GetPlayerIDs(month, day);
            List<string> playerIdsDayBefore = data.GetPlayerIDs(month, _dayBefore);
            List<string> matchedPlayers = new List<string>();

            foreach (string usr in playerIds)
            {
                if (playerIdsDayBefore.Contains((usr)))
                    matchedPlayers.Add((usr));
            }

            float matched = matchedPlayers.Count;
            float playersFromDayBefore = playerIdsDayBefore.Count;

            float retention = (matched / playersFromDayBefore) * 100f;

            return retention + "%";
        }

    }
}
