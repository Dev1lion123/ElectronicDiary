using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicDiary.Entities
{

    public class User
    {
        [Key]
        public int Id { get; set; }

        [Index(IsUnique = true)]
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

        //public virtual List<Student> Student { get; set; }
        //public virtual List<Teacher> Teachers { get; set; }
    }
}
