using System.ComponentModel.DataAnnotations;

namespace ElectronicDiary.Entities
{
    public partial class Subject
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        //public virtual ICollection<Class> Classes { get; set; }
        //public virtual ICollection<Grade> Grades { get; set; }
    }
}
