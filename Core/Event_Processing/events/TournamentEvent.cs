using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Event_Processing.events
{
    public class TournamentEvent : Event
    {
        EventProcessor processor;

        List<Event> tournamentEvents;
        int gamesPlayed;
        int gamesLost;
        int gamesWon;
        int adsWatched;

        string type;
        string level;
        string belt;


        public int GamesPlayed { get => gamesPlayed; set => gamesPlayed = value; }
        public int GamesLost { get => gamesLost; set => gamesLost = value; }
        public int GamesWon { get => gamesWon; set => gamesWon = value; }
        public int AdsWatched { get => adsWatched; set => adsWatched = value; }
        public string Type { get => type; set => type = value; }
        public string Level { get => level; set => level = value; }
        public string Belt { get => belt; set => belt = value; }

        public TournamentEvent(Event tournamentEvent)
        {
            Type = tournamentEvent.EventValue.Split('_')[0];
            Level = tournamentEvent.EventValue.Split('_')[1];
            Belt = tournamentEvent.EventValue.Split('_')[2];
        }

        public TournamentEvent(EventProcessor processor)
        {
            this.processor = processor;

            tournamentEvents = processor.GetEventsByScene("fight");
        }
        

        void CalculateGameMetrics()
        {
            //TODO
            throw new NotImplementedException();   
        }

        public void Print()
        {
            for (int i = 0; i < tournamentEvents.Count; i++)
            {
                tournamentEvents[i].Print(i);
            }
        }
    }
}
