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
        string[] eventDataBuffer = new string[512];

        string country;
        public string Country { get { return country; } set { country = value; } }
        string dateAndTime;
        public string DateAndTime { get { return dateAndTime; } set { dateAndTime = value; } }
        string dateAndTimeUTC;
        public string DateAndTimeUTC { get { return dateAndTimeUTC; } set { dateAndTimeUTC = value; } }
        string scene;
        public string Scene { get {return scene; } set {scene = value; } }
        string eventName;
        public string EventName { get { return eventName; } set { eventName = value; } }
        string eventValue;
        public string EventValue { get { return eventValue; } set { eventValue = value; } }
        string date;
        public string Date { get { return date; } set { date = value; } }
        string year;
        public string Year { get { return year; } set { year = value; } }
        string month;
        public string Month { get { return month; } set { month = value; } }
        string day;
        public string Day { get { return day; } set { day = value; } }
        string time;
        public string Time { get { return time; } set { time = value; } }
        string hour;
        public string Hour { get { return hour; } set { hour = value; } }
        string minute;
        public string Minute { get { return minute; } set { minute = value; } }
        string second;
        public string Second { get { return second; } set { second = value; } }

        public Event()
        {

        }

        public Event(string playerData, char splitChar = ',')
        {
            eventDataBuffer = playerData.Split(splitChar);

            country = eventDataBuffer[1];
            dateAndTime = eventDataBuffer[2];
            dateAndTimeUTC = eventDataBuffer[3];
            scene = eventDataBuffer[4];
            eventName = eventDataBuffer[5];
            eventValue = eventDataBuffer[6];

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
            Console.WriteLine("I: " + i);
            Console.WriteLine("DATE/TIME: " + dateAndTime);
            Console.WriteLine("SCENE: " + scene);
            Console.WriteLine("EVENT NAME: " + eventName);
            Console.WriteLine("EVENT VALUE: " + eventValue);
            Console.WriteLine("*********************");
        }
    }

}
