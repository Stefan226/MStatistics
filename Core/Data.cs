using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Data
    {
        string rawData;
        List<string> allData = new List<string>();
        List<PlayerData> players = new List<PlayerData>();
        string[] playerIDs = new string[2048];

        int DAU;

        public Data()
        {
            
        }

        public Data(string path)
        {
            rawData = ReadAll(path);
            FilterData(rawData);
        }


        string ReadAll(string path)
        {
            string data = "";
            string finalPath = "Analytics/" + path;

            if (Directory.Exists(finalPath) && path != "")
            {
                foreach (string file in Directory.GetFiles(finalPath, "*.txt"))
                {
                    data += File.ReadAllText(file);
                }
                return data;
            }
            Console.WriteLine(finalPath);
            Console.WriteLine("Invalid Date");
            Console.WriteLine("Enter the date in the following format yyyy-mm-dd: ");
            return ReadAll(Console.ReadLine());
        }

        void FilterData(string rawData, char splitChar = '&')
        {
            int splitIterator = 0;
            List<string> playerData = new List<string>();

            for (int i = 0; i < rawData.Length; i++)
            {
                if (rawData[i] == splitChar)
                {
                    allData.Add(rawData.Split(splitChar)[splitIterator]);
                    playerIDs[splitIterator] = allData[splitIterator].Split(',')[0];

                    if (splitIterator > 0)
                    {
                        playerData.Add(allData[splitIterator - 1]);
                        if (playerIDs[splitIterator - 1] != playerIDs[splitIterator])
                        {
                            players.Add(new PlayerData(playerData));
                            DAU++;
                            playerData.Clear();
                        }
                    }

                    splitIterator++;
                }
            }
        }

        public List<string> LoadPlayerData(string playerID)
        {
            if (playerID == "")
            {
                Console.WriteLine("Enter playerID, example: g18148900640404897985");
                return LoadPlayerData(Console.ReadLine());
            }

            List<string> playerData = new List<string>();

            foreach (string id in allData)
            {
                if (id.StartsWith(playerID))
                    playerData.Add(id);
            }
            return playerData;
        }

        public PlayerData GetPlayerData(string playerID)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].PlayerID == playerID)
                    return players[i];
            }

            return null;
        }

        public void Print()
        {
            foreach (string str in allData)
            {
                Console.WriteLine(str);
            }
        }

        public int GetDailyActiveUsers()
        {
            return DAU + 1;
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
                second = 60 - second*-1;
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

        public string GetAvgSessionTime(TIME timeFormat)
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
