using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicDiary.Entities;
using ElectronicDiary.Models;
using static ElectronicDiary.Models.StudentPageModel;
using StudentPageModel = ElectronicDiary.Models.StudentPageModel;

namespace ElectronicDiary.ViewModels
{

    public class StudentPageViewModel : INotifyPropertyChanged
    {
        //private int grade = StudentPageModel.GetGrades();
        //public ObservableCollection<Grades> Grade
        //{
        //    get => grade;
        //    set
        //    {
        //        grade = value;
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Grade)));
        //    }
        //}


        public event PropertyChangedEventHandler PropertyChanged;

        private int?[] marksCollection = StudentPageModel.GetGrades();
        public int?[] MarksCollection
        {
            get => marksCollection;
            set
            {
                marksCollection = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MarksCollection)));
            }
        }
        private string[] gradesRowHeader = StudentPageModel.GetSubjectsTitles();
        public string[] GradesRowHeader
        {
            get => gradesRowHeader;
            set
            {
                gradesRowHeader = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GradesRowHeader)));
            }
        }
        private string[] gradesColumnHeader = StudentPageModel.GetDates();
        public string[] GradesColumnHeader
        {
            get => gradesColumnHeader;
            set
            {
                gradesColumnHeader = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GradesColumnHeader)));
            }
        }

        //public List<Classes> AllClasses { get; set; }
        private ObservableCollection<SchoolDay> dayOfWeeks = StudentPageModel.GetDays();
        public ObservableCollection<SchoolDay> DayOfWeeks
        {
            get
            {
                return dayOfWeeks;
            }

            set
            {
                dayOfWeeks = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DayOfWeeks)));
            }
        }
        public StudentPageViewModel()
        {
            AllClasses = ClassForData.Entity.Classes.ToList();
            //marksCollection = Observable1.electronic_DiaryEntities.Grades.Where(it => it.ID_Student == Observable1.UserID).Select(it => it.Grade).ToArray(); 
            //var SubjectsTitle = Observable1.electronic_DiaryEntities.Grades.Where(it => it.ID_Student == Observable1.UserID).Select(it => it.Subjects.Title).Distinct().ToArray();
            //var MarksDate = Observable1.electronic_DiaryEntities.Grades.Where(it => it.ID_Student == Observable1.UserID).Select(it => it.Date.ToString()).Distinct().ToArray();
            //gradesColumnHeader = MarksDate;
            //gradesRowHeader = SubjectsTitle;
            //GetDays();
        }
    }
}