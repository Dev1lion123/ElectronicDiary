using System.ComponentModel.DataAnnotations;

namespace ElectronicDiary.Entities
{
    public partial class TeacherGroup
    {
        [Key]
        //[ForeignKey("ID")]
        public int Id { get; set; }

        //[ForeignKey("ID_Teacher")]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        //[ForeignKey("ID_Group")]
        public int GroupId { get; set; }
        public Group Group { get; set; }

        //public List<Group> Groups { get; set; }
        //public List<Teacher> Teachers { get; set; }
    }
}
