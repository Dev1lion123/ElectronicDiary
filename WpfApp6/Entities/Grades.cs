using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicDiary.Entities
{
    public partial class Grades
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("ID_Subject")]
        public int ID_Subject { get; set; }
        [ForeignKey("ID_Student")]
        public int ID_Student { get; set; }
        [ForeignKey("ID_Group")]
        public int ID_Group { get; set; }
        [ForeignKey("ID_Teacher")]
        public int ID_Teacher { get; set; }
        public Nullable<int> Grade { get; set; }
        public string Assessment_comment { get; set; }
        public System.DateTime Date { get; set; }

        public virtual Groups Groups { get; set; }
        public virtual Student Student { get; set; }
        public virtual Subjects Subjects { get; set; }
        public virtual Teachers Teachers { get; set; }
    }
}
