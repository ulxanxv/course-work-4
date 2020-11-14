using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Railway.Entity {

    [Table("RailwayTicket")]
    public class RailwayTicket {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public Train Train { get; set; }

        [ForeignKey("Train")]
        public virtual int TrainId { get; set; } 

        [Required]
        public Person Person { get; set; }

        [ForeignKey("Person")]
        public virtual int PersonId { get; set; }

        [Required]
        [StringLength(100)]
        public string PointOfDeparture { get; set; }

        [Required]
        [StringLength(100)]
        public string PointOfArrival { get; set; }

        public DateTime DepartureTime { get; set; }

        [Required]
        public DateTime ArrivalTime { get; set; }

        [Required]
        public int CarriageNumber { get; set; }

        [Required]
        public int SeatOfCarriage { get; set; }

        [Required]
        public decimal TicketPrice { get; set; }

        public RailwayTicket Update {
            set {
                TrainId = value.TrainId;
                PersonId = value.PersonId;
                PointOfDeparture = value.PointOfDeparture;
                PointOfArrival = value.PointOfArrival;
                DepartureTime = value.DepartureTime;
                ArrivalTime = value.ArrivalTime;
                CarriageNumber = value.CarriageNumber;
                SeatOfCarriage = value.SeatOfCarriage;
                TicketPrice = value.TicketPrice;
            }
        }

    }
}
