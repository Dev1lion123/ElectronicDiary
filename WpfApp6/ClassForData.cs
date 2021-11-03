using ElectronicDiary.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicDiary
{
    public static class ClassForData // Класс для передачи данных между формами (Знаю, что можно обойтись без него, но пока что так, пока не решим основные задачи
    {
        public static int UserID { get; set; }
        public static int GroupID { get; set; }
        public static int TeacherID { get; set; }
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> collection)
        {
            ObservableCollection<T> obscoll = new ObservableCollection<T>();
            collection.ToList().ForEach(it => obscoll.Add(it));
            return obscoll;
        }
        public static T[,] To2DArray<T>(this IEnumerable<IEnumerable<T>> source) 
        {
            var data = source
                .Select(x => x.ToArray())
                .ToArray();

            var res = new T[data.Length, data.Max(x => x.Length)];
            for (var i = 0; i < data.Length; ++i)
            {
                for (var j = 0; j < data[i].Length; ++j)
                {
                    res[i, j] = data[i][j];
                }
            }

            return res;
        }
        public static DbStudents Entity = new DbStudents();
    }
}
