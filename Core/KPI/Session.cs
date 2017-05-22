using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Event_Processing;

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

            if (second < 0 && minute >= 0)
            {
                minute--;
                second = 60 - Math.Abs(second);
            }

            return hour * 3600 + minute * 60 + second;
        }

        public int GetSessionTimeInt(Event begin, Event end)
		{
            int hour = Convert.ToInt32(end.Hour) - Convert.ToInt32(begin.Hour);
            int minute = Convert.ToInt32(end.Minute) - Convert.ToInt32(begin.Minute);
            int second = Convert.ToInt32(end.Second) - Convert.ToInt32(begin.Second);

			if (second < 0 && minute >= 0)
			{
				minute--;
				second = 60 - Math.Abs(second);
			}

			return hour * 3600 + minute * 60 + second;
		}

        public string GetAvgSessionTime(List<PlayerData> players, TIME timeFormat)
        {
            float avgSessionTime = 0;
            int playerCountFilter = 0;

            foreach (PlayerData player in players)
            {
                avgSessionTime += GetSessionTimeInt(player);
                if (GetSessionTimeInt(player) > 10)
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

        public string GetTotalSessionTime(PlayerData player)
        {
            EventProcessor processor = new EventProcessor(player);

            Event begin;
            Event end;

            int finalTime = 0;
            int index = 0;

            while (processor.GetEventByName("GameExit") != null)
            {
                begin = processor.GetEventByName("GameOpen");
                end = processor.GetEventByName("GameExit");

                processor.RemoveEvent(begin);
                processor.RemoveEvent(end);

                finalTime += GetSessionTimeInt(begin, end);
                index++;
            }

            Console.WriteLine("FINAL: " + finalTime);

            return ReturnHours(finalTime) + ":" + ReturnMinutes(finalTime) + ":" + ReturnSecounds(finalTime);
        }

		public string ReturnHours(int time)
		{
			int hrs = (time / 3600);
			if (hrs >= 10)
				return hrs + "";
			return "0" + hrs;
		}
		public string ReturnMinutes(int time)
		{
			int hrs = (time / 3600);
			int min = (time / 60) - hrs * 60;
			if (min >= 10)
				return min + "";
			return "0" + min;
		}
		public string ReturnSecounds(int time)
		{
			int sec = (time % 60);
			if (sec >= 10)
				return sec + "";
			return "0" + sec;
		}
    }
}
