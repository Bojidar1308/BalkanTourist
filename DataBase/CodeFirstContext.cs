using Microsoft.EntityFrameworkCore;
using System;

namespace DataBase
{
    public class CodeFirstContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<ClientsReservation> ClientsReservations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BalkanTouristData;");
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>()
                .HasOne(a => a.User)
                .WithMany(b => b.Reservations)
                .HasForeignKey(b => b.Id);

            modelBuilder.Entity<Reservation>()
                .HasOne(a => a.Room)
                .WithMany(b => b.Reservations)
                .HasForeignKey(b => b.Id);

            modelBuilder.Entity<ClientsReservation>()
                .HasKey(cr => new { cr.ReservationsId, cr.ClientId });

            modelBuilder.Entity<ClientsReservation>()
                .HasOne(a => a.Client)
                .WithMany(b => b.ClientsReservations)
                .HasForeignKey(b => b.ClientId);

            modelBuilder.Entity<ClientsReservation>()
               .HasOne(a => a.Reservation)
               .WithMany(b => b.ClientsReservations)
               .HasForeignKey(b => b.ReservationsId);
        }

    }
}
