using System.ComponentModel.DataAnnotations;

namespace ElectronicDiary.Entities
{

    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        //попиваю кофеечек
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        //
        //public virtual List<Student> Student { get; set; }
        //public virtual List<Teacher> Teachers { get; set; }
    }
}
