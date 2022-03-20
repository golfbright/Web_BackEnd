using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TMSAPI.Models
{
    public partial class TMSContext : DbContext
    {
        

        public TMSContext(DbContextOptions<TMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<AccountRole> AccountRoles { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<TaskList> TaskList { get; set; }
        public virtual DbSet<Transports> Transport { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.CardId).HasMaxLength(13);

                entity.Property(e => e.DriverLicense).HasMaxLength(8);

                entity.Property(e => e.EmployeeNo)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.ImageProfilePath).HasMaxLength(500);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.Status).IsRequired();

                entity.Property(e => e.Tel).HasMaxLength(10);
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.AddressNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.District)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Gps)
                 .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NamePlace)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.Property(e => e.VehicleBrand)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.VehiclePlate)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.VehicleStatus)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.VehicleType)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleName).IsRequired();
            });

            modelBuilder.Entity<TaskList>(entity =>
            {
                entity.Property(e => e.TaskNumber).HasMaxLength(50);
                entity.Property(e => e.TaskDate).HasColumnType("datetime");

                entity.Property(e => e.TaskDetail)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.TaskFinishDate).HasColumnType("datetime");

                entity.Property(e => e.TaskStartDate).HasColumnType("datetime");

                entity.Property(e => e.TaskStatus)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
