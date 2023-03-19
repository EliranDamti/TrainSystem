using System;
using TrainSystem.Enum;
using TrainSystem.ViewModel;

namespace TrainSystem
{
    class MainWindowViewModel : BindAbleBase
    {
        private AddTrainViewModel addTrainViewModel = new AddTrainViewModel();
        private HomeViewModel homeViewModel = new HomeViewModel();
        private SearchViewModel searchViewModel = new SearchViewModel();

        public bool isEnabledHome { get; set; }
        public bool isEnabledSearch { get; set; }
        public bool isEnabledAdd { get; set; }
        public bool isEnabledEditAndRemove { get; set; }
        public RelayCommand<ViewModelSName> NavigateCommand { get; set; }

        private BindAbleBase currentViewModel;
        public BindAbleBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                IsEnabled(currentViewModel, value);
                currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public object ViewModelEnum { get; private set; }

        private void IsEnabled(BindAbleBase currentViewModel, BindAbleBase newValue)
        {
            var currentViewModelName = currentViewModel?.GetType().Name;

            var newValueViewModelName = newValue?.GetType().Name;

            var currentViewModelSuccess = System.Enum.TryParse(
                currentViewModelName, out ViewModelSName currentViewModelEnum);

            var newValueSuccess = System.Enum.TryParse(
                newValueViewModelName, out ViewModelSName newValueViewModelEnum);

            if (!currentViewModelSuccess || !newValueSuccess)
            {
                return;
            }

            switch (currentViewModelEnum, newValueViewModelEnum)
            {
                case (ViewModelSName.HomeViewModel, ViewModelSName.AddTrainViewModel):
                    isEnabledHome = true;
                    isEnabledAdd = false;
                    break;
                case ( ViewModelSName.AddTrainViewModel ,ViewModelSName.HomeViewModel):
                    isEnabledAdd = true;
                    isEnabledHome = false;
                    break;
                case (ViewModelSName.HomeViewModel, ViewModelSName.SearchViewModel):
                    isEnabledHome = true;
                    isEnabledSearch = false;
                    break;
                case (ViewModelSName.SearchViewModel, ViewModelSName.HomeViewModel):
                    isEnabledSearch = true;
                    isEnabledHome = false;
                    break;
                case (ViewModelSName.SearchViewModel, ViewModelSName.AddTrainViewModel):
                    isEnabledSearch = true;
                    isEnabledAdd = false;
                    break;
                case (ViewModelSName.AddTrainViewModel, ViewModelSName.SearchViewModel):
                    isEnabledAdd = true;
                    isEnabledSearch = false;
                    break;
            }

            OnPropertyChanged(nameof(isEnabledHome));
            OnPropertyChanged(nameof(isEnabledAdd));
            OnPropertyChanged(nameof(isEnabledSearch));
        }

        public MainWindowViewModel()
        {
            NavigateCommand = new RelayCommand<ViewModelSName>(Navigate);
            currentViewModel = homeViewModel;
            isEnabledHome = false;
            isEnabledSearch = true;
            isEnabledAdd = true;
            isEnabledEditAndRemove = true;
        }
        private void Navigate(ViewModelSName viewModelName)
        {
            switch (viewModelName)
            {
                case ViewModelSName.AddTrainViewModel:
                    CurrentViewModel = addTrainViewModel;
                    break;
                case ViewModelSName.HomeViewModel:
                    CurrentViewModel = homeViewModel;
                    break;
                case ViewModelSName.SearchViewModel:
                    CurrentViewModel = searchViewModel;
                    break;
                case ViewModelSName.mockViewModel:
                    break;
            }

        }
    }
}
