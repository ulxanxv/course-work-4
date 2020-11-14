using Railway.Entity;
using System.Data.Entity;
using System.Data.SqlClient;

namespace Railway {

    public class ApplicationContext : DbContext {

        public ApplicationContext() : base("DbConnectionString") {
            this.Database.CreateIfNotExists();
        }

        public DbSet<Train> Trains { get; set; }
        public DbSet<TrainType> TrainTypes { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<RailwayTicket> RailwayTickets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {

            modelBuilder.Entity<Person>()
                .HasIndex(p => new { p.PassportSeries, p.PassportId })
                .IsUnique();

            modelBuilder.Entity<RailwayTicket>()
                .HasIndex(p => new { p.CarriageNumber, p.SeatOfCarriage })
                .IsUnique();

        }



    }
}
