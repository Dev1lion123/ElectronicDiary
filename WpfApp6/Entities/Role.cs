using System.ComponentModel.DataAnnotations;

namespace ElectronicDiary.Entities
{
    public partial class Role
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        //public List<User> Users { get; set; }
    }
}
