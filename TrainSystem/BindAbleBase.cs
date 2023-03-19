using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TrainSystem
{
    public class BindAbleBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
