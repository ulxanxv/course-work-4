using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Railway.Entity {

    [Table("TrainType")]
    public class TrainType {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public virtual ICollection<Train> Trains { get; set; }

        [Required]
        [StringLength(50)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public TrainType Update {
            set {
                Name = value.Name;
            }
        }

    }
}
