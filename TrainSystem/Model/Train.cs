using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TrainSystem.Model
{
    public class Train : BindAbleBase
    {
        private string crew1;
        public string Crew1
        {
            get => crew1; 
            set
            {
                crew1 = value;
                OnPropertyChanged(nameof(Crew1));
            }
        }

        private string crew2;
        public string Crew2
        {
            get => crew2;
            set
            {
                crew2 = value;
                OnPropertyChanged(nameof(Crew2));
            }
        }

        private int type;
        public int Type
        {
            get => type;
            set
            {
                type = value;
                OnPropertyChanged(nameof(Type));
            }
        }

        public Station StartStation
        {
            get
            {
                return ListOfSegments[0]?.Start;
            }
        }
        public Station StopStation { get
            {
                return ListOfSegments[ListOfSegments.Count-1]?.Stop;
            }
        }

        public List<Segment> ListOfSegments { get; set; }

        public static ObservableCollection<Train> MockTrains()
        {
            var trains = new ObservableCollection<Train>();

            var segments1 = new List<Segment>(); 
            var segments2 = new List<Segment>();
            var segments3 = new List<Segment>();
            var segments4 = new List<Segment>();

            segments1.Add(new Segment
            {
                Start = new Station
                {
                    ArrivalTime = new DateTime(1000,1,1,8,30,0),
                    StationName = "Nahariyya"
                }
                ,
                Stop= new Station
                {
                    ArrivalTime = new DateTime(1000, 1, 1, 8, 37, 0),
                    StationName = "Akko"
                }
            });



            segments1.Add(new Segment
            {
                Start = new Station
                {
                    ArrivalTime = new DateTime(1000, 1, 1, 8, 37, 0),
                    StationName = "Akko"
                }
               ,
                Stop = new Station
                {
                    ArrivalTime = new DateTime(1000, 1, 1, 8, 45, 0),
                    StationName = "Kiryat Biyalik"
                }
            });

            segments2.Add(new Segment
            {
                Start = new Station
                {
                    ArrivalTime = new DateTime(1000, 1, 1, 11, 00, 0),
                    StationName = "Beer Sheva"
                }
               ,
                Stop = new Station
                {
                    ArrivalTime = new DateTime(1000, 1, 1, 11, 28, 0),
                    StationName = "Lod"
                }
            });

            segments3.Add(new Segment
            {
                Start = new Station
                {
                    ArrivalTime = new DateTime(1000, 1, 1, 12, 00, 0),
                    StationName = "haifa"
                }
               ,
                Stop = new Station
                {
                    ArrivalTime = new DateTime(1000, 1, 1, 13, 28, 0),
                    StationName = "tel aviv"
                }
            });

            segments4.Add(new Segment
            {
                Start = new Station
                {
                    ArrivalTime = new DateTime(1000, 1, 1, 20, 00, 0),
                    StationName = "herzeliya"
                }
               ,
                Stop = new Station
                {
                    ArrivalTime = new DateTime(1000, 1, 1, 21, 34, 0),
                    StationName = "binyamina"
                }
            });



            trains.Add(new Train { crew1 = "a", crew2 = "a", type = 1 , ListOfSegments=segments1 });

            trains.Add(new Train { crew1 = "b", crew2 = "b", type = 2, ListOfSegments = segments2 });

            trains.Add(new Train { crew1 = "c", crew2 = "c", type = 3, ListOfSegments = segments3 });

            trains.Add(new Train { crew1 = "d", crew2 = "d", type = 4, ListOfSegments = segments4 });

            return trains;
        }
    }
}
