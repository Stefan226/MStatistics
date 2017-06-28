using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Core.KPI;
using Core.Event_Processing;
using Core.Event_Processing.events;
using Core.Exporters;

namespace Core
{
    class Program
    {
        static bool overrideAll;

        static void Main(string[] args)
        {
<<<<<<< HEAD
            Data data = new Data(MONTHS.JUNE, "25");            
            //Data data = new Data("2017-04-30", "zizi1999901");
=======
            DirectoryInit("analytics");
            DirectoryInit("csv");
>>>>>>> 9d1d4fecb72b19b885a6cb47d146d4e6e6bc86ec

            SaveCSVDATA(true);
        }

<<<<<<< HEAD
            PlayerData playerData = data.GetPlayerData("g07341007839018303203");
=======
        public static void SaveCSVDATA(bool showDateOptions)
        {
            string month;
            string dayB = "";
            string dayE = "";

            month = ChooseMonth(showDateOptions);

            string daysMethodChosen = ChooseDayOrDays(showDateOptions);

            if (daysMethodChosen == "1")
            {
                string tempDay = ChooseDay(showDateOptions);

                dayB = tempDay;
                dayE = dayB;
            }
            else if (daysMethodChosen == "2")
            {
                string[] tempDays = ChooseDayRange(showDateOptions);

                dayB = tempDays[0];
                dayE = tempDays[1];
            }
            else
            {
                Console.WriteLine("Wrong Input!");
                SaveCSVDATA(true);
            }

            int dayBInt = Convert.ToInt32(dayB);
            int dayEInt = Convert.ToInt32(dayE);

            for (int i = dayBInt; i <= dayEInt; i++)
            {
                CSV(month, i + "");
            }

            Console.WriteLine("Convert new file? 1.Yes 2.No");
            string answer = Console.ReadLine();

            if (answer == "1")
            {
                overrideAll = false;
                SaveCSVDATA(true);
            }
        }
>>>>>>> 9d1d4fecb72b19b885a6cb47d146d4e6e6bc86ec

        public static void CSV(string month, string day)
        {
            if (Data.CheckIfDataExists(Data.MonthChosen(month), day))
            {
                if (!CSVExporter.CheckIfCsvExists(month, day))
                {
                    Console.WriteLine("Working...");
                    new Data().InitRawData(Data.MonthChosen(month), day).SaveToCSV(month + "-" + day);
                }
                else
                {
                    if (!overrideAll)
                    {
                        Console.WriteLine("That file is already exported");
                        Console.WriteLine("Would you like to override it? 1.Yes 2.No 3.OverrideAll");
                        if (Console.ReadLine() == "3")
                            overrideAll = true;
                    }
                    if (overrideAll)
                    {
                        File.Delete(month + "-" + day);
                        Console.WriteLine("Working...");
                        new Data().InitRawData(Data.MonthChosen(month), day).SaveToCSV(month + "-" + day);
                    }
                    else if (Console.ReadLine() == "1" && !overrideAll)
                    {
                        File.Delete(month + "-" + day);
                        Console.WriteLine("Working...");
                        new Data().InitRawData(Data.MonthChosen(month), day).SaveToCSV(month + "-" + day);
                    }
                    else
                        SaveCSVDATA(true);
                }
            }
            else
            {
                Console.WriteLine("That file doesn't exsist!");
                SaveCSVDATA(true);
            }
        }

        public static string ChooseMonth(bool showOptions)
        {
            if (showOptions)
                Console.WriteLine("Choose month:\n 1 - January\n 2 - February\n 3 - March\n" +
                    " 4 - April\n 5 - May\n 6 - June\n 7 - July\n 8 - August\n 9 - September\n 10 - October\n 11 - November\n 12 - December");

            int month = Convert.ToInt32(Console.ReadLine());

            if (month >= 1 && month <= 12)
                return month + "";
            else
                Console.WriteLine("Wrong month chosen!");

<<<<<<< HEAD
            Console.WriteLine("Weekly Active Users: " + new DAU().GetActiveUsers(MONTHS.JUNE, "21", "22"));
            Console.WriteLine("Weekly Active Users AVG: " + new DAU().GetActiveUsersAVG(MONTHS.JUNE, "21", "22"));
=======
            return ChooseMonth(false);
        }
>>>>>>> 9d1d4fecb72b19b885a6cb47d146d4e6e6bc86ec

        public static string ChooseDayOrDays(bool showOptions)
        {
            if (showOptions)
                Console.WriteLine("1.Single Day 2.Multiple Days (range)");

            string answer = Console.ReadLine();

            if (answer == "1")
                return "1";
            else if (answer == "2")
                return "2";
            else
            {
                Console.WriteLine("Wrong input!");
                ChooseDayOrDays(true);
            }

            return "";
        }

        public static string[] ChooseDayRange(bool showOptions)
        {
            string[] newRange = new string[2];

            if (showOptions)
                Console.WriteLine("Choose begin day 1-(30, 31, 28)");
            int dayB = Convert.ToInt32(Console.ReadLine());

            if (showOptions)
                Console.WriteLine("Choose end day 1-(30, 31, 28)");
            int dayE = Convert.ToInt32(Console.ReadLine());

            if (dayE < dayB)
            {
                Console.WriteLine("Wrong Input! End is Greater than Begining");
                return ChooseDayRange(true);
            }

<<<<<<< HEAD
            Console.WriteLine("RETENTIONDAY1: " + new Retention().GetRetentionDayOne(MONTHS.JUNE, "21"));
            Console.WriteLine("RETENTIONDAY7: " + new Retention().GetRetentionDaySeven(MONTHS.JUNE, "21"));
=======
            if (dayB >= 1 && dayB <= 31 && dayE >= 1 && dayE <= 31)
            {
                newRange[0] = dayB + "";
                newRange[1] = dayE + "";
>>>>>>> 9d1d4fecb72b19b885a6cb47d146d4e6e6bc86ec

                return newRange;
            }
            else
                Console.WriteLine("Wrong day chosen");

            return ChooseDayRange(false);
        }

<<<<<<< HEAD
			//Console.WriteLine("Session Time: " + new Session().GetTotalSessionTime(playerData));
=======
        public static string ChooseDay(bool showOptions)
        {
            if (showOptions)
                Console.WriteLine("Choose Day 1-(30, 31, 28)");
>>>>>>> 9d1d4fecb72b19b885a6cb47d146d4e6e6bc86ec

            int day = Convert.ToInt32(Console.ReadLine());

<<<<<<< HEAD
            //EventProcessor processor = new EventProcessor(data.GetPlayerData("g00132286129678147304"));
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


            CsvExporter exporter = new CsvExporter(data);
            exporter.CreateCSVString().SaveToFile("csvText");

            Console.ReadLine();
=======
            if (day >= 1 && day <= 31)
                return day + "";
            else
                Console.WriteLine("Wrong day chosen");

            return ChooseDay(false);
        }
>>>>>>> 9d1d4fecb72b19b885a6cb47d146d4e6e6bc86ec

        public static void DirectoryInit(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }


    }
}
