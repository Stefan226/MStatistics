﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
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

    public class Data
    {
        string rawData;
        List<string> allData = new List<string>();
        List<PlayerData> players = new List<PlayerData>();
        string[] playerIDs;
        int numberOfFiles;

        public Data()
        {

        }

        public Data(MONTHS month, string day, string username)
        {
            rawData = ReadOnePlayer(month, day, username);
            playerIDs = new string[512];
            FilterData(rawData);
        }

        public Data(MONTHS month, string day)
        {
            rawData = ReadAll(month, day);
            playerIDs = new string[15000];
            FilterData(rawData);
        }


        string ReadAll(MONTHS month, string day)
        {
            string data = "";

            int _month = (int)month;
            string finalMonth = "";

            if ((int)month < 10)
                finalMonth = "0" + _month;
            else
                finalMonth = _month + "";

            string finalPath = "Analytics/" + "2017-" + finalMonth + "-" + day;

            if (Directory.Exists(finalPath) && day != "")
            {
                foreach (string file in Directory.GetFiles(finalPath, "*.txt"))
                {
                    data += File.ReadAllText(file);
                    numberOfFiles++;
                }
                return data + "END";
            }
            Console.WriteLine(finalPath);
            Console.WriteLine("Invalid Date");
            Console.WriteLine("Enter the date in the following format yyyy-mm-dd: ");
            return ReadAll(month, Console.ReadLine());
        }

        string ReadOnePlayer(MONTHS month, string day, string username)
        {
            string data = "";

            int _month = (int)month;
            string finalMonth = "";

            if ((int)month < 10)
                finalMonth = "0" + _month;
            else
                finalMonth = _month + "";

            string finalPath = "Analytics/" + "2017-" + finalMonth + "-" + day;

            if (Directory.Exists(finalPath) && day != "")
            {
                foreach (string file in Directory.GetFiles(finalPath, "*.txt"))
                {
                    if (file.Split('\\')[1].StartsWith(username))
                    {
                        data += File.ReadAllText(file);
                        numberOfFiles++;
                    }
                }
                return data + "END";
            }
            Console.WriteLine(finalPath);
            Console.WriteLine("Invalid Date");
            Console.WriteLine("Enter the date in the following format yyyy-mm-dd: ");
            return ReadOnePlayer(month, Console.ReadLine(), Console.ReadLine());
        }

        void FilterData(string rawData, char splitChar = '&')
        {
            List<string> playerData = new List<string>();
            string[] rawDataSplit = rawData.Split(splitChar);

            for (int i = 0; i < rawDataSplit.Length - 1; i++)
            {
                allData.Add(rawDataSplit[i]);
                playerIDs[i] = allData[i].Split(',')[1];

                if (i > 0)
                {
                    playerData.Add(allData[i - 1]);

                    if (playerIDs[i - 1] != playerIDs[i])
                    {
                        players.Add(new PlayerData(playerData));
                        playerData.Clear();
                    }
                    else if (rawDataSplit[i + 1] == "END")
                    {
                        playerData.Add(allData[i]);
                        players.Add(new PlayerData(playerData));
                    }
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

        public PlayerData GetPlayerData(string idOrUsername)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].PlayerID == idOrUsername || players[i].PlayerUsername == idOrUsername)
                    return players[i];
            }

            return null;
        }

        public List<string> GetPlayerUsernames(MONTHS month, string day)
        {
            int _month = (int)month;
            string finalMonth = "";

            if ((int)month < 10)
                finalMonth = "0" + _month;
            else
                finalMonth = _month + "";

            string finalPath = "Analytics/" + "2017-" + finalMonth + "-" + day;

            List<string> usernames = new List<string>();

            if (Directory.Exists(finalPath))
            {
                foreach (string file in Directory.GetFiles(finalPath, "*.txt"))
                {
                    usernames.Add(file.Split(' ')[0].Split(Path.DirectorySeparatorChar)[2]);
                }
                return usernames;
            }

            return null;
        }

		public List<string> GetPlayerIDs(MONTHS month, string day)
		{
			int _month = (int)month;
			string finalMonth = "";

			if ((int)month < 10)
				finalMonth = "0" + _month;
			else
				finalMonth = _month + "";

			string finalPath = "Analytics/" + "2017-" + finalMonth + "-" + day;

            List<string> usernames = new List<string>();

			if (Directory.Exists(finalPath))
			{
				foreach (string file in Directory.GetFiles(finalPath, "*.txt"))
				{
                    usernames.Add(file.Split(' ')[2].Split('.')[0]);
                }
				return usernames;
			}

			return null;
		}

        public List<PlayerData> GetPlayers()
        {
            return players;
        }

        public void Print()
        {
            foreach (string str in allData)
            {
                Console.WriteLine(str);
            }
        }
    }
}
