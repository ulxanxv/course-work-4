using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Railway.Entity {

    [Table("StudentParent")]
    public class StudentParent {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public virtual Student Student { get; set; }

        [ForeignKey("Student")]
        public virtual int StudentId { get; set; }

        [Required]
        public virtual Parent Parent { get; set; }

        [ForeignKey("Parent")]
        public virtual int ParentId { get; set; }

        public StudentParent Update {
            set {
                StudentId   = value.StudentId;
                ParentId    = value.ParentId;
            }
        }

    }
}
