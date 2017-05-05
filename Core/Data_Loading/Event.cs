using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public enum TIME
    {
        SECONDS,
        MINUTES,
        HOURS
    }

    public class Event
    {
        string[] eventDataBuffer;

        string country;
        string dateAndTime;
        string dateAndTimeUTC;
        string scene;
        string eventName;
        string eventValue;
        string date;
        string year;
        string month;
        string day;
        string time;
        string hour;
        string minute;
        string second;

        public string Country { get => country; set => country = value; }
        public string DateAndTime { get => dateAndTime; set => dateAndTime = value; }
        public string DateAndTimeUTC { get => dateAndTimeUTC; set => dateAndTimeUTC = value; }
        public string Scene { get => scene; set => scene = value; }
        public string EventName { get => eventName; set => eventName = value; }
        public string EventValue { get => eventValue; set => eventValue = value; }
        public string Date { get => date; set => date = value; }
        public string Year { get => year; set => year = value; }
        public string Month { get => month; set => month = value; }
        public string Day { get => day; set => day = value; }
        public string Time { get => time; set => time = value; }
        public string Hour { get => hour; set => hour = value; }
        public string Minute { get => minute; set => minute = value; }
        public string Second { get => second; set => second = value; }

        public Event()
        {

        }

        public Event(string playerData, char splitChar = ',')
        {
            eventDataBuffer = new string[playerData.Split(splitChar).Length];
            eventDataBuffer = playerData.Split(splitChar);

            country = eventDataBuffer[2];
            dateAndTime = eventDataBuffer[3];
            dateAndTimeUTC = eventDataBuffer[4];
            scene = eventDataBuffer[5];
            eventName = eventDataBuffer[6];
            eventValue = eventDataBuffer[7];

            date = dateAndTime.Split(' ')[0].Split(':')[1];
            year = date.Split('/')[2];
            month = date.Split('/')[0];
            day = date.Split('/')[1];

            time = dateAndTime.Split(' ')[1];
            hour = time.Split(':')[0];
            minute = time.Split(':')[1];
            second = time.Split(':')[2];
        }

        public void Print(int i)
        {
            Console.WriteLine("E: " + (i + 1));
            Console.WriteLine("DATE/TIME: " + dateAndTime);
            Console.WriteLine("SCENE: " + scene);
            Console.WriteLine("EVENT NAME: " + eventName);
            Console.WriteLine("EVENT VALUE: " + eventValue);
            Console.WriteLine("*********************");
        }
    }

}
