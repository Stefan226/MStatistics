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
        string[] playerIDs;
        int numberOfFiles;

        public Data()
        {

        }

        public Data(string path, string username)
        {
            rawData = ReadOnePlayer(path, username);
            playerIDs = new string[512];
            FilterData(rawData);
        }

        public Data(string path)
        {
            rawData = ReadAll(path);
            playerIDs = new string[8000];
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
                    numberOfFiles++;
                }
                return data + "END";
            }
            Console.WriteLine(finalPath);
            Console.WriteLine("Invalid Date");
            Console.WriteLine("Enter the date in the following format yyyy-mm-dd: ");
            return ReadAll(Console.ReadLine());
        }

        string ReadOnePlayer(string path, string username)
        {
            string data = "";
            string finalPath = "Analytics/" + path;

            if (Directory.Exists(finalPath) && path != "")
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
                    playerIDs[splitIterator] = allData[splitIterator].Split(',')[1];

                    if (splitIterator > 0)
                    {
                        playerData.Add(allData[splitIterator - 1]);

                        if (playerIDs[splitIterator - 1] != playerIDs[splitIterator])
                        {
                            players.Add(new PlayerData(playerData));
                            playerData.Clear();
                        }
                        else if (rawData.Split(splitChar)[splitIterator + 1] == "END")
                        {
                            playerData.Add(allData[splitIterator]);
                            players.Add(new PlayerData(playerData));
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

        public PlayerData GetPlayerData(string idOrUsername)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].PlayerID == idOrUsername || players[i].PlayerUsername == idOrUsername)
                    return players[i];
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
