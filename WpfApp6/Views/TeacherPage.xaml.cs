using ElectronicDiary.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ElectronicDiary.Views
{
    /// <summary>
    /// Логика взаимодействия для TeacherPage.xaml
    /// </summary>
    public partial class TeacherPage : Page, INotifyPropertyChanged
    {
        public ObservableCollection<TeacherGroup> AllTeacher_Groups { get; set; }
        public TeacherPage()
        {
            InitializeComponent();
            DataContext = this;
            AllTeacher_Groups = ClassForData.Entity.TeacherGroups.Where(it => it.TeacherId == ClassForData.TeacherID).ToObservableCollection();

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Student> selectedGroups;
        public ObservableCollection<Student> SelectedGroups
        {
            get
            {
                return selectedGroups;
            }
            set
            {
                selectedGroups = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedGroups)));
            }
        }
        private void GroupList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TeacherGroup groups1 = GroupList.SelectedItem as TeacherGroup;
            SelectedGroups = ClassForData.Entity.Students.Where(it => it.GroupId == groups1.GroupId).ToObservableCollection();
            if (SelectedGroups.Any())
            {
                StudentsDataGrid.ItemsSource = SelectedGroups;
            }
            else { }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AuthPage());
        }
    }
}
