using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Railway.Entity {

    [Table("StudentPerformace")]
    public class StudentPerformance {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public virtual Student Student { get; set; }

        [ForeignKey("Student")]
        public virtual int StudentId { get; set; }

        [Required]
        public virtual Discipline Discipline { get; set; }

        [ForeignKey("Discipline")]
        public virtual int DisciplineId { get; set; }

        [StringLength(50)]
        public string TeacherSurname { get; set; }

        public int AmountOfHours { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public StudentPerformance Update {
            set {
                StudentId       = value.StudentId;
                DisciplineId    = value.DisciplineId;
                TeacherSurname  = value.TeacherSurname;
                AmountOfHours   = value.AmountOfHours;
                Rating          = value.Rating;
                Date            = value.Date;
            }
        }

    }

}
