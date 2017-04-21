using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Core.KPI;

namespace Core
{
    class Program
    {
        static void Main(string[] args)
        {
            string pid = "g18148900640404897985";

            Console.WriteLine("Enter the date in the following format yyyy-mm-dd: ");
            Data data = new Data(/*Console.ReadLine()*/"2017-04-16");

            Console.WriteLine("Data Loaded!");

            Console.WriteLine("Enter playerID, example: g18148900640404897985");
            string playerID = Console.ReadLine();
            //PlayerData playerData = new PlayerData(data.LoadPlayerData(playerID));

            PlayerData playerData = data.GetPlayerData(playerID);

            playerData.Print();
            //data.Print();

            Session session = new Session();

            Console.WriteLine("Daily Active Users: " + new DAU().GetDailyActiveUsers("2017-04-16"));
            Console.WriteLine(session.GetSessionTime(playerData));
            Console.WriteLine(session.GetSessionTimeInt(playerData));
            Console.WriteLine("Average session: " + session.GetAvgSessionTime(data.GetPlayers(), TIME.MINUTES));

            Console.ReadLine();
        }
    }
}
