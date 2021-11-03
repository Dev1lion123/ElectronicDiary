using System.ComponentModel.DataAnnotations;

namespace ElectronicDiary.Entities
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        //public List<Class> Classes { get; set; }
        //public List<Grade> Grades { get; set; }
        //public List<Student> Student { get; set; }
        //public List<Teacher_Groups> Teacher_Groups { get; set; }
    }
}

