using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

            Console.WriteLine("Daily Active Users: " + data.GetDailyActiveUsers());
            Console.WriteLine(data.GetSessionTime(playerData));
            Console.WriteLine(data.GetSessionTimeInt(playerData));
            Console.WriteLine("Average session: " + data.GetAvgSessionTime(TIME.SECONDS));
            Console.WriteLine("Average session: " + data.GetAvgSessionTime(TIME.MINUTES));

            Console.ReadLine();
        }
    }
}
