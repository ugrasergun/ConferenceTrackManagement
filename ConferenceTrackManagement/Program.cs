using ConferenceTrackManagement.Entities;
using ConferenceTrackManagement.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceTrackManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Conference conf = new Conference();
            conf.Schedule(Helper.GetInputData());
            Console.Write(conf.getSchedule());
        }
    }
}
