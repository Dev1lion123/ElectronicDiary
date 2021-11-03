using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicDiary.Entities
{
    [Table("Classes")]
    public partial class ClassEntity
    {
        [Key]
        public int Id { get; set; }

        //[ForeignKey("ID_Subject")]
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        //[ForeignKey("ID_Teacher")]
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        public string AssessmentComment { get; set; }
        public DateTime Date { get; set; }

        //[ForeignKey("ID_Group")]
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }

    }
}
