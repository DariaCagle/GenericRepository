using FuneralHome.Data.Entities;
using System.Data.Entity;

namespace FuneralHome.Data
{
    public class FuneralHomeContext : DbContext
    {
        public FuneralHomeContext() : base("Default") { }

        public DbSet<Funeral> Funerals { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<FuneralEmployee> FuneralEmployees { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Funeral>()
                .HasRequired(x => x.Client)
                .WithMany(x => x.Funerals)
                .HasForeignKey(x => x.ClientId);

            modelBuilder.Entity<FuneralEmployee>()
                .HasRequired(x => x.Funeral)
                .WithMany(x => x.FuneralEmployees)
                .HasForeignKey(x => x.FuneralId);

            modelBuilder.Entity<FuneralEmployee>()
                .HasRequired(x => x.Employee)
                .WithMany(x => x.FuneralEmployees)
                .HasForeignKey(x => x.EmployeeId);

            modelBuilder.Entity<FuneralEmployee>()
                .Property(x => x.FuneralId)
                .HasColumnName("Funeral_Id");

            modelBuilder.Entity<FuneralEmployee>()
                .Property(x => x.EmployeeId)
                .HasColumnName("Employee_Id");

            modelBuilder.Entity<FuneralEmployee>()
                .ToTable("FuneralEmployees")
                .HasKey(x => new { x.FuneralId, x.EmployeeId });
        }
    }
}
