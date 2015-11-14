using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConferenceTrackManagement.Entities
{
    public class Track
    {
        public Track()
        {
            MorningLastTime = new TimeSpan(9, 0, 0);
            AfternoonLastTime = new TimeSpan(13, 0, 0);
            MorningSession = new List<IEvent>();
            AfternoonSession = new List<IEvent>();
        }

        
        public List<IEvent> MorningSession { get; set; }
        public List<IEvent> AfternoonSession { get; set; }
        public TimeSpan MorningLastTime { get; set; }
        public TimeSpan AfternoonLastTime { get; set; }

        public bool AddToMorningSession(IEvent TrackEvent)
        {
            if (MorningLastTime + TrackEvent.Duration > new TimeSpan(12,0,0))
                return false;
            if (TrackEvent.SetStartTime(MorningLastTime))
            {
                MorningLastTime = TrackEvent.EndTime;
                MorningSession.Add(TrackEvent);
                return true;
            }
            return false;
        }
        public bool AddToAfternoonSession(IEvent TrackEvent)
        {
           
            if (AfternoonLastTime + TrackEvent.Duration > new TimeSpan(17, 0, 0) && !(TrackEvent is NetworkingEvent))
                return false;
            if (TrackEvent.SetStartTime(AfternoonLastTime))
            {
                AfternoonLastTime = TrackEvent.EndTime;
                AfternoonSession.Add(TrackEvent);
                return true;
            }
            return false;
        }
    }
}
