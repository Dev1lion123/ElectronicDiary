using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicDiary.Entities
{
    public partial class Student
    {
        public Student()
        {
            this.Grades = new HashSet<Grades>();
        }
        [Key]
        public int ID { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Patronymic { get; set; }
        public string E_mail { get; set; }
        public Nullable<decimal> Phone { get; set; }
        [ForeignKey("ID_Group")]
        public int ID_Group { get; set; }
        [ForeignKey("ID_User")]
        public int ID_User { get; set; }
        public int Course { get; set; }

      
        public virtual ICollection<Grades> Grades { get; set; }
        public virtual Groups Groups { get; set; }
        public virtual Users Users { get; set; }
    } 
}
