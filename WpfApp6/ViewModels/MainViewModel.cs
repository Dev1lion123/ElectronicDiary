using ElectronicDiary.Entities;
using Simplified;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicDiary.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {
        private ViewMode _viewMode;
        private RelayCommand _viewModeCommand;

        public ViewMode ViewMode { get => _viewMode; set =>Set(ref _viewMode, value); }

        public RelayCommand ViewModeCommand => _viewModeCommand ??= new RelayCommand<ViewMode>(mode => ViewMode = mode);

        private readonly DbStudents dbStudents = new DbStudents();
    }
}
