using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Railway.Entity {

    [Table("Student")]
    public class Student {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public virtual ICollection<StudentPerformance> StudentPerformances { get; set; }

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
        public string Gender { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Address { get; set; }

        public Student Update { 
            set {
                FirstName   = value.FirstName;
                LastName    = value.LastName;
                MiddleName  = value.MiddleName;
                Gender      = value.Gender;
                DateOfBirth = value.DateOfBirth;
                Phone       = value.Phone;
                Address     = value.Address;
            }
        }

    }

}
