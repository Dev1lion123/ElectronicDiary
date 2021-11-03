using System.ComponentModel.DataAnnotations;

namespace ElectronicDiary.Entities
{
    public partial class Teacher
    {
        [Key]
        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Patronymic { get; set; }
        public string E_mail { get; set; }
        public string Phone { get; set; }

        //[ForeignKey("ID_User")]
        public int UserId { get; set; }
        public User User { get; set; }

        //public virtual ICollection<Class> Classes { get; set; }
        //public virtual ICollection<Grade> Grades { get; set; }
        //public virtual ICollection<TeacherGroups> Teacher_Groups { get; set; }
    }
}
