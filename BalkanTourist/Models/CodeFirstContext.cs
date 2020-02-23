using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace BalkanTourist
{
    public class CodeFirstContext : IdentityDbContext<User>
    {
        public CodeFirstContext()
        {
            ; ;
        }
        public CodeFirstContext(DbContextOptions<CodeFirstContext> options) : base(options)
        {
            ; ;
        }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<ClientsReservation> ClientsReservations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HotelDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(b =>
            {
                b.ToTable("User");
            });
            modelBuilder.Entity<IdentityRole>(b =>
            {
                b.ToTable("Role");
            });
            modelBuilder.Entity<IdentityUserRole<string>>(b =>
            {
                b.ToTable("UserRole");
            });
            modelBuilder.Entity<Reservation>()
                .HasOne(a => a.User)
                .WithMany(b => b.Reservations)
                .HasForeignKey(b => b.UserID);

            modelBuilder.Entity<Reservation>()
                .HasOne(a => a.Room)
                .WithMany(b => b.Reservations)
                .HasForeignKey(b => b.RoomId);

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
