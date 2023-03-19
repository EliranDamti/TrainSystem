using System;
using System.Collections.ObjectModel;
using TrainSystem.Model;

namespace TrainSystem.ViewModel
{
    class AddTrainViewModel : BindAbleBase
    {
        public ObservableCollection<Train> Trains { get; set; }

        public AddTrainViewModel()
        {
            Stam = new RelayCommand<Train>(foo);
            Trains = Train.MockTrains();
            
        }

        private void foo(Train t)
        {
            t.Type++;
            t.OnPropertyChanged(nameof(Type));
        }

        public RelayCommand<Train> Stam { get; set; }
    }
}
