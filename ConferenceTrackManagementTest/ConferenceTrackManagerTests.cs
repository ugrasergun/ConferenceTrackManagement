using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConferenceTrackManagement.Entities;

namespace ConferenceTrackManagementTest
{
    [TestClass]
    public class ConferenceTrackManagerTests
    {
        [TestMethod]
        public void InitializeTalk()
        {
            IEvent talk = new Talk("Writing Fast Tests Against Enterprise Rails 60min");
            Assert.AreEqual(talk.Duration, new TimeSpan(1, 0, 0));
            Assert.AreEqual(talk.EventName, "Writing Fast Tests Against Enterprise Rails");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void FailInitializeTalk()
        {
            IEvent talk = new Talk("Writing Fast Tests Against Enterprise Rails 60minutes");
        }

        [TestMethod]
        public void SetTalkStart()
        {
            IEvent talk = new Talk("Writing Fast Tests Against Enterprise Rails 60min");
            talk.SetStartTime(new TimeSpan(10, 0, 0));
            Assert.AreEqual(talk.StartTime, new TimeSpan(10, 0, 0));
            Assert.AreEqual(talk.EndTime, new TimeSpan(11, 0, 0));
        }

        [TestMethod]
        public void FalseTalkStartTime()
        {
            IEvent talk = new Talk("Writing Fast Tests Against Enterprise Rails 60min");
            bool result = false;
            result |= talk.SetStartTime(new TimeSpan(8, 0, 0));
            result |= talk.SetStartTime(new TimeSpan(12, 30, 0));
            result |= talk.SetStartTime(new TimeSpan(18, 0, 0));
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SetNetworkingStart()
        {
            IEvent nEvent = new NetworkingEvent();
            bool result = nEvent.SetStartTime(new TimeSpan(16, 30, 0));
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void FalseNetworkingStart()
        {
            IEvent nEvent = new NetworkingEvent();
            bool result = nEvent.SetStartTime(new TimeSpan(17, 30, 0));
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AddToMorning()
        {
            Track t = new Track();
            t.MorningLastTime = new TimeSpan(11,0,0);
            IEvent talk = new Talk("Writing Fast Tests Against Enterprise Rails 60min");
            bool result = t.AddToMorningSession(talk);
            Assert.IsTrue(result);
            Assert.AreEqual(t.MorningSession.Count, 1);
            Assert.AreEqual(t.MorningLastTime, new TimeSpan(12, 0, 0));
            result = t.AddToMorningSession(talk);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AddToAfternoon()
        {
            Track t = new Track();
            t.AfternoonLastTime = new TimeSpan(13, 0, 0);
            IEvent talk = new Talk("Writing Fast Tests Against Enterprise Rails 60min");
            bool result = t.AddToAfternoonSession(talk);
            Assert.IsTrue(result);
            Assert.AreEqual(t.AfternoonSession.Count, 1);
            Assert.AreEqual(t.AfternoonLastTime, new TimeSpan(14, 0, 0));
            t.AfternoonLastTime = new TimeSpan(17, 0, 0);
            result = t.AddToAfternoonSession(talk);
            Assert.IsFalse(result);
        }
    }
}
