using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Railway.Entity {

    [Table("Discipline")]
    public class Discipline {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public virtual ICollection<StudentPerformance> StudentPerformances { get; set; }

        [Required]
        public string Name { get; set; }

        public Discipline Update {
            set {
                Name = value.Name;
            }
        }

    }

}
