using System;
using System.Collections.ObjectModel;

namespace TrainSystem.Model
{
    public static class TrainListClass
    {
        public static ObservableCollection<Train> Trains { get; set; } = Train.MockTrains();
           
    }
}
