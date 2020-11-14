using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Railway.Entity {

    [Table("Train")]
    public class Train {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public virtual TrainType Type { get; set; }

        [ForeignKey("Type")]
        public virtual int TypeId { get; set; }

        public virtual ICollection<RailwayTicket> RailwayTickets { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(50)]
        public string Model { get; set; }

        [Required]
        public decimal MaxSpeed { get; set; }

        [Required]
        public int AmountSeat { get; set; }

        [Required]
        [StringLength(50)]
        public string ManufacturerCountry { get; set; }

        public Train Update {
            set {
                TypeId = value.TypeId;
                Model = value.Model;
                MaxSpeed = value.MaxSpeed;
                AmountSeat = value.AmountSeat;
                ManufacturerCountry = value.ManufacturerCountry;
            }
        }

    }
}
