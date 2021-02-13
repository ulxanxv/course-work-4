using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Railway.Entity {

    [Table("Parent")]
    public class Parent {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public virtual ICollection<StudentParent> StudentParents { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }

        [Required]
        public string Phone { get; set; }

        public Parent Update {
            set {
                FirstName   = value.FirstName;
                LastName    = value.LastName;
                MiddleName  = value.MiddleName;
                Phone       = value.Phone;
            }
        }

    }

}
