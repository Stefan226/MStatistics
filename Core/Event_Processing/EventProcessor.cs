using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Event_Processing
{
    public class EventProcessor
    {
        List<Event> events;

        public EventProcessor(PlayerData player)
        {
            events = player.GetEvents();
        }

        public Event GetEventByName(string name)
        {
            for (int i = 0; i < events.Count; i++)
            {
                if (events[i].EventName == name)
                    return events[i];
            }
            return null;
        }

        public List<Event> GetEventsByName(string name)
        {
            List<Event> filteredEvents = new List<Event>();

            for (int i = 0; i < events.Count; i++)
            {
                if (events[i].EventName == name)
                    filteredEvents.Add(events[i]);
            }
            return filteredEvents;
        }

        public Event GetEventByValue(string value)
        {
            for (int i = 0; i < events.Count; i++)
            {
                if (events[i].EventName == value)
                    return events[i];
            }
            return null;
        }

        public List<Event> GetEventsByValue(string value)
        {
            List<Event> filteredEvents = new List<Event>();

            for (int i = 0; i < events.Count; i++)
            {
                if (events[i].EventName == value)
                    filteredEvents.Add(events[i]);
            }
            return filteredEvents;
        }

        public Event GetEventByScene(string scene)
        {
            for (int i = 0; i < events.Count; i++)
            {
                if (events[i].Scene == scene)
                    return events[i];
            }
            return null;
        }

        public List<Event> GetEventsByScene(string scene)
        {
            List<Event> filteredEvents = new List<Event>();

            for (int i = 0; i < events.Count; i++)
            {
                if (events[i].Scene == scene)
                    filteredEvents.Add(events[i]);
            }
            return filteredEvents;
        }

        public int GetEventsCount()
        {
            return events.Count;
        }



    }
}
