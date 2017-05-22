using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class PlayerData
    {
        string playerID;
        public string PlayerID { get { return playerID; } set {playerID = value; } }

        string playerUsername;
        public string PlayerUsername { get => playerUsername; set => playerUsername = value; }


        List<string> playerData = new List<string>();
        List<Event> events = new List<Event>();

        public PlayerData()
        {
            
        }

        public PlayerData(List<string> playerData)
        {
            this.playerData = playerData;
            string[] player = playerData[0].Split(',');

            playerUsername = player[0];
            playerID = player[1];
            AddEvents();
        }
    

        void AddEvents()
        {
            foreach (string str in playerData)
            {
                events.Add(new Event(str));
            }
        }

        public Event GetEventData(int i)
        {
            if (events[i] != null)
                return events[i];
            return null;
        }

        public void Print()
        {
            Console.WriteLine("USERNAME: " + playerUsername);
            Console.WriteLine("PlayerID: " + playerID);
            Console.WriteLine("COUNTRY: " + events[0].Country);
            for (int i = 0; i < events.Count; i++)
            {
                Console.WriteLine("E: " + (i + 1) + "\n" + events[i]);
            }
        }

        public int GetEventCount()
        {
            return events.Count;
        }

        public int GetPlayerDataCount()
        {
            return playerData.Count;
        }

        public List<Event> GetEvents()
        {
            return events;
        }
    }
}
