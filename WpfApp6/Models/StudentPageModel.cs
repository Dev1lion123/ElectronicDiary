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
            public List<Classes> CurrentClasses { get; set; }
            public string dayOfWeek { get; set; }
            public DateTime DateOf { get; set; }
            public SchoolDay(List<Classes> classes)
            {
                CurrentClasses = classes;
                dayOfWeek = classes.First().Date.DayOfWeek.ToString();
                DateOf = classes.First().Date;
            }
        }

        public static int?[] GetGrades()
        {
            using (DB_Context Entity = new DB_Context())
            {
                var Result = Entity.Grades.Where(it => it.ID_Student == ClassForData.UserID).Select(it => it.Grade).ToArray(); //Отбор данных для получения оценок
                return Result;
            }
        }
        public static string[] GetSubjectsTitles()
        {
            using (DB_Context Entity = new DB_Context())
            {
                var Result = Entity.Grades.Where(it => it.ID_Student == ClassForData.UserID).Select(it => it.Subjects.Title).Distinct().ToArray(); //Отбор данных для получения названий предметов
                return Result;
            }
        }
        public static string[] GetDates()
        {
            using (DB_Context Entity = new DB_Context())
            {
                var Result = Entity.Grades.Where(it => it.ID_Student == ClassForData.UserID).Select(it => it.Date.ToString()).Distinct().ToArray(); //Отбор данных для получения дат оценок
                return Result;
            }
        }

        public static List<Classes> AllClasses = ClassForData.Entity.Classes.ToList();
        public static ObservableCollection<SchoolDay> GetDays()
        {
            List<SchoolDay> dayOfWeeks = new List<SchoolDay>();
            var groupClasses = AllClasses.Where(it => it.ID_Group == ClassForData.GroupID);//поиск по группе(id)
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
    

