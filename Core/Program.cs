using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Core.KPI;
using Core.Event_Processing;
using Core.Event_Processing.events;

namespace Core
{
    class Program
    {
        static void Main(string[] args)
        {
            Data data = new Data(MONTHS.APRIL, "30");            
            //Data data = new Data("2017-04-30", "zizi1999901");

            Console.WriteLine("Data Loaded!");

            PlayerData playerData = data.GetPlayerData("g06768074634392902084");

            playerData.Print();
            ////data.Print();

            Console.WriteLine(playerData.PlayerUsername);

            //Session session = new Session();

            Console.WriteLine("Weekly Active Users: " + new DAU().GetActiveUsers(MONTHS.APRIL, "23", "24"));
            Console.WriteLine("Weekly Active Users AVG: " + new DAU().GetActiveUsersAVG(MONTHS.APRIL, "23", "24"));

            //List<string> usernames = data.GetPlayerUsernames(MONTHS.APRIL, "25");
            //foreach (string username in usernames)
            //{
            //    Console.WriteLine(username);
            //}

            Console.WriteLine("Weekly Active Users: " + new DAU().GetActiveUsers(MONTHS.APRIL, "23", "30"));
            Console.WriteLine("Weekly Active Users AVG: " + new DAU().GetActiveUsersAVG(MONTHS.APRIL, "23", "30"));




            Console.WriteLine("RETENTION: " + new Retention().GetRetentionDayOne(MONTHS.APRIL, "30"));


            //Console.WriteLine("Session Time: " + session.GetTotalSessionTime(playerData));

            //Console.WriteLine(session.GetSessionTime(playerData));
            //Console.WriteLine(session.GetSessionTimeInt(playerData));
            //Console.WriteLine("Average session: " + session.GetAvgSessionTime(data.GetPlayers(), TIME.MINUTES));

            //EventProcessor processor = new EventProcessor(data.GetPlayerData("g11990376020229995298"));
            //try
            //{
            //    TournamentEvent tournament = new TournamentEvent(processor);
            //    tournament.Print();
            //    Console.WriteLine("Games Won: " + tournament.GamesWon);
            //    Console.WriteLine("Games Lost: " + tournament.GamesLost);
            //    Console.WriteLine("Ads Watched: " + tournament.AdsWatched);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //}

            Console.ReadLine();

        }
    }
}
