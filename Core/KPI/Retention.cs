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
                if (playerIdsDayBefore.Contains(usr))
                    matchedPlayers.Add((usr));
            }

            float matched = matchedPlayers.Count;
            float playersFromDayBefore = playerIdsDayBefore.Count;

            float retentionDayOne = (matched / playersFromDayBefore) * 100f;

            return retentionDayOne + "%";
    }

        public string GetRetentionDaySeven(MONTHS month, string day)

        {

            string finalPath = "Analytics/" + "2017-" + (int)month + "-" + day;

            if ((int)month < 10)
                finalPath = "Analytics/" + "2017-" + "0" + (int)month + "-" + day;

            Data data = new Data();

            int sevenDayBefore = Convert.ToInt32(day) - 7;

            string _sevenDayBefore = sevenDayBefore + "";

            if (sevenDayBefore < 10)
                _sevenDayBefore = "0" + sevenDayBefore;

            List<string> playerIds = data.GetPlayerIDs(month, day);
            List<string> playerIdsSevenDayBefore = data.GetPlayerIDs(month, _sevenDayBefore);
            List<string> matchedPlayers = new List<string>();

            foreach (string usr in playerIds)
            {

                if (playerIdsSevenDayBefore.Contains(usr))
                    matchedPlayers.Add(usr);
            }

            float matched = matchedPlayers.Count;
            float playerFromSevenDaysBefore = playerIdsSevenDayBefore.Count;

            float retentionDaySeven = (matched / playerFromSevenDaysBefore) * 100;

            return retentionDaySeven + "%";
        }

        //public string GetRetentionDayOneNewPlayers (MONTHS month, string day)

        //{

            //string finalPath = "Analytics/" + "2017-" + (int)month + "-" + day;

			//if ((int)month < 10)
				//finalPath = "Analytics/" + "2017-" + "0" + (int)month + "-" + day;

            //Data data = new Data();
            //Event _event = new Event();

	   		//int dayBefore = Convert.ToInt32(day) - 1;

			//string _dayBefore = dayBefore + "";

			//if (dayBefore < 10)
				//_dayBefore = "0" + dayBefore;

			//List<string> playerIds = data.GetPlayerIDs(month, day);
            //List<string> playerIdsDayBefore = data.GetPlayerIDs(month, _dayBefore);
			//List<string> matchedPlayers = new List<string>();



        
        //}

    }
}
