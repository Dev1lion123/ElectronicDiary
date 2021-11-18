using ElectronicDiary.Entities;
using Simplified;

namespace ElectronicDiary.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {
        private ViewMode _viewMode;
        private RelayCommand _viewModeCommand;

        public ViewMode ViewMode { get => _viewMode; set => Set(ref _viewMode, value); }

        public RelayCommand ViewModeCommand => _viewModeCommand ??= new RelayCommand<ViewMode>(mode => ViewMode = mode);

        private readonly DbStudents dbStudents;

        public MainViewModel()
        {
            if (!IsInDesignMode)
                dbStudents = new DbStudents();
        }
    }
}
