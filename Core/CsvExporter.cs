using System;
using System.IO;

namespace Core
{
    public class CsvExporter
    {

        Data data;
        string rawCsvString;

        public CsvExporter(Data data)
        {
            this.data = data;
        }

        public CsvExporter CreateCSVString()
        {
            foreach (PlayerData playerData in data.GetPlayers())
            {
                foreach (Event e in playerData.GetEvents())
                {
                    rawCsvString += (CheckString(e.DateAndTime) + "," + CheckString(e.Scene) + "," + CheckString(e.EventName) + "," + CheckString(e.EventValue) + "\n");
                }
            }

            return this;
        }

        public void SaveToFile(string fileName)
        {
            if (fileName == "")
                throw new Exception("String is Empty");
            else
                File.WriteAllText("csv/" + fileName + ".txt", rawCsvString);
        }


        public string CheckString(string eventParam)
        {
            if (eventParam == "")
                return "null";
            else
                return eventParam;
        }
    }
}
