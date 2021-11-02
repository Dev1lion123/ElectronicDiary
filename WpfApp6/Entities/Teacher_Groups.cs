using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicDiary.Entities
{
    public partial class Teacher_Groups
    {
        [Key]
        [ForeignKey("ID")]
        public int ID { get; set; }
        [ForeignKey("ID_Teacher")]
        public int ID_Teacher { get; set; }
        [ForeignKey("ID_Group")]
        public int ID_Group { get; set; }

        public virtual List<Groups> Groups { get; set; }
        public virtual List<Teachers> Teachers { get; set; }
    }
}
