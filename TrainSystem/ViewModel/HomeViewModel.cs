using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TrainSystem.Model;

namespace TrainSystem.ViewModel
{
    class HomeViewModel : BindAbleBase
    {
        public ObservableCollection<Train> TrainList { get; set; }

        public HomeViewModel()
        {
            TrainList = TrainListClass.Trains;
        }

    }
}
