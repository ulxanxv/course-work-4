using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Railway.Entity {

    [Table("Person")]
    public class Person {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(4)]
        public string PassportSeries { get; set; }

        [Required]
        [StringLength(6)]
        public string PassportId { get; set; }

        [Required]
        [StringLength(50)]
        public string SecondName { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }

        public string FullPassport {
            get {
                return (PassportSeries + PassportId);
            }
        }

        public Person Update {
            set {
                PassportSeries = value.PassportSeries;
                PassportId = value.PassportId;
                SecondName = value.SecondName;
                FirstName = value.FirstName;
                MiddleName = value.MiddleName;
            }
        }

    }
}
