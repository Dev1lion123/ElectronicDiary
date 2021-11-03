using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicDiary.Entities;
using ElectronicDiary.ViewModels;

namespace ElectronicDiary.Models
{
    public class StudentPageModel
    {
        public class SchoolDay
        {
            public List<ClassEntity> CurrentClasses { get; set; }
            public string dayOfWeek { get; set; }
            public DateTime DateOf { get; set; }
            public SchoolDay(List<ClassEntity> classes)
            {
                CurrentClasses = classes;
                dayOfWeek = classes.First().Date.DayOfWeek.ToString();
                DateOf = classes.First().Date;
            }
        }

        public static int?[] GetGrades()
        {
            using (DbStudents Entity = new DbStudents())
            {
                var Result = Entity.Grades.Where(it => it.StudentId == ClassForData.UserID).Select(it => it.Value).ToArray(); //Отбор данных для получения оценок
                return Result;
            }
        }
        public static string[] GetSubjectsTitles()
        {
            using (DbStudents Entity = new DbStudents())
            {
                var Result = Entity.Grades.Where(it => it.StudentId == ClassForData.UserID).Select(it => it.Subject.Title).Distinct().ToArray(); //Отбор данных для получения названий предметов
                return Result;
            }
        }
        public static string[] GetDates()
        {
            using (DbStudents Entity = new DbStudents())
            {
                var Result = Entity.Grades.Where(it => it.StudentId == ClassForData.UserID).Select(it => it.Date.ToString()).Distinct().ToArray(); //Отбор данных для получения дат оценок
                return Result;
            }
        }

        public static List<ClassEntity> AllClasses = ClassForData.Entity.Classes.ToList();
        public static ObservableCollection<SchoolDay> GetDays()
        {
            List<SchoolDay> dayOfWeeks = new List<SchoolDay>();
            var groupClasses = AllClasses.Where(it => it.GroupId == ClassForData.GroupID);//поиск по группе(id)
            var allDays = AllClasses.Select(it => it.Date).Distinct();//исключение повторений(вычисление даты)
            foreach (var item in allDays)
            {
                var days = groupClasses.Where(it => it.Date == item);
                if (days.Any())
                    dayOfWeeks.Add(new SchoolDay(days.ToList()));
                else
                { }
            }
            return dayOfWeeks.ToObservableCollection();
        }
    }
}
    

