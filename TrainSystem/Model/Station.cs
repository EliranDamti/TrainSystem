using System;

namespace TrainSystem.Model
{
    public class Station
    {
        public string StationName { get; set; }
        public DateTime ArrivalTime { get; set; }

        public string ArrivalTimeString
        {
            get
            {
                return ArrivalTime.ToString("HH:mm");
            }
        }
    }
}