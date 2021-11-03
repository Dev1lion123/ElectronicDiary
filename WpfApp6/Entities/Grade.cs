using System;
using System.ComponentModel.DataAnnotations;

namespace ElectronicDiary.Entities
{
    public class Grade
    {
        [Key]
        public int Id { get; set; }

        //[ForeignKey("ID_Subject")]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        //[ForeignKey("ID_Student")]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        //[ForeignKey("ID_Group")]
        public int GroupId { get; set; }
        public Group Group { get; set; }


        //[ForeignKey("ID_Teacher")]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }


        public int? Value { get; set; }
        public string AssessmentComment { get; set; }
        public DateTime Date { get; set; }

    }
}
