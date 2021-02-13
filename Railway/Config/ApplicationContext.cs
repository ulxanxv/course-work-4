using Railway.Entity;
using System.Data.Entity;

namespace Railway {

    public class ApplicationContext : DbContext {

        public ApplicationContext() : base("DbConnectionString") {
            this.Database.CreateIfNotExists();
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<StudentParent> StudentParents { get; set; }
        public DbSet<StudentPerformance> StudentPerformances { get; set; }

    }
}
