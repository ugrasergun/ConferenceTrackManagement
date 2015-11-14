using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceTrackManagement.Entities
{
    public class Conference
    {
        public Conference()
        {
            tracks = new List<Track>();
        }
        public List<Track> tracks { get; set; }

        public void Schedule(List<string> eventList)
        {
            List<IEvent> talks = new List<IEvent>();
            foreach (var eventItem in eventList)
            {
                talks.Add(new Talk(eventItem));
            }

            
            foreach (var talk in talks.OrderByDescending(tlk => tlk.Duration))
            {
                bool isInMorning = false;
                bool isInAfternoon = false;
                for (int i = 0; i < tracks.Count; i++)
                {
                    isInMorning = tracks[i].AddToMorningSession(talk);
                    if (isInMorning)
                    {
                        if(tracks[i].MorningLastTime == new TimeSpan(12,0,0))
                        {
                            tracks[i].MorningSession.Add(new Lunch());
                        }
                        break;
                    }
                    isInAfternoon = tracks[i].AddToAfternoonSession(talk);
                    if (isInAfternoon)
                    {
                        if(tracks[i].AfternoonLastTime > new TimeSpan(16,0,0))
                        {
                            IEvent nEvent = new NetworkingEvent();
                            if (nEvent.SetStartTime(tracks[i].AfternoonLastTime))
                            {
                                tracks[i].AddToAfternoonSession(nEvent);
                            }
                        }
                        break;
                    }
                }
                if (!(isInMorning || isInAfternoon))
                {
                    Track track = new Track();
                    track.AddToMorningSession(talk);
                    tracks.Add(track);
                }
              
            }
        }

        public string getSchedule()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < tracks.Count; i++)
            {
                sb.AppendLine(string.Format("Track {0}:", i + 1));
                for (int j = 0; j < tracks[i].MorningSession.Count; j++)
                {
                    sb.AppendLine(string.Format("{0}:{1} {2}", tracks[i].MorningSession[j].StartTime.Hours.ToString("00"), tracks[i].MorningSession[j].StartTime.Minutes.ToString("00"), tracks[i].MorningSession[j].EventName));
                }
                for (int j = 0; j < tracks[i].AfternoonSession.Count; j++)
                {
                    sb.AppendLine(string.Format("{0}:{1} {2}", tracks[i].AfternoonSession[j].StartTime.Hours.ToString("00"), tracks[i].AfternoonSession[j].StartTime.Minutes.ToString("00"), tracks[i].AfternoonSession[j].EventName));
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
