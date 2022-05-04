using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SharedClassModels.DataModels
{
    public partial class AirlineDBContext : DbContext
    {
        public AirlineDBContext()
        {
        }

        public AirlineDBContext(DbContextOptions<AirlineDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAdminDetail> TblAdminDetails { get; set; }
        public virtual DbSet<TblAirlineRegister> TblAirlineRegisters { get; set; }
        public virtual DbSet<TblBookingdetail> TblBookingdetails { get; set; }
        public virtual DbSet<TblFlightdetail> TblFlightdetails { get; set; }
        public virtual DbSet<TblPassengerList> TblPassengerLists { get; set; }
        public virtual DbSet<TblUserName> TblUserNames { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=AirlineDB;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblAdminDetail>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("tblAdminDetails");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.AdminName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AdminPwd)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblAirlineRegister>(entity =>
            {
                entity.HasKey(e => e.AirlineId);

                entity.ToTable("tblAirlineRegister");

                entity.Property(e => e.AirlineId)
                    .ValueGeneratedNever()
                    .HasColumnName("airlineID");

                entity.Property(e => e.AirlineName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("airlineName");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.RegOn)
                    .HasColumnType("datetime")
                    .HasColumnName("regOn");
            });

            modelBuilder.Entity<TblBookingdetail>(entity =>
            {
                entity.HasKey(e => e.BookingId);

                entity.ToTable("tblBookingdetails");

                entity.Property(e => e.BookingId)
                    .ValueGeneratedNever()
                    .HasColumnName("bookingID");

                entity.Property(e => e.FlightId).HasColumnName("flightID");

                entity.Property(e => e.MailId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("mailID");

                entity.Property(e => e.MealsAvailed)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("mealsAvailed");

                entity.Property(e => e.NumOfSeats).HasColumnName("numOfSeats");

                entity.Property(e => e.PnrNo).HasColumnName("pnrNo");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userName");
            });

            modelBuilder.Entity<TblFlightdetail>(entity =>
            {
                entity.HasKey(e => e.FlightId);

                entity.ToTable("tblFlightdetails");

                entity.Property(e => e.FlightId)
                    .ValueGeneratedNever()
                    .HasColumnName("flightID");

                entity.Property(e => e.AirlineId).HasColumnName("airlineID");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("endDate");

                entity.Property(e => e.FromPlace)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fromPlace");

                entity.Property(e => e.InstrUsed)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("instrUsed");

                entity.Property(e => e.MealDetails)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("mealDetails");

                entity.Property(e => e.NoofRows).HasColumnName("noofRows");

                entity.Property(e => e.NumBusinessSeats).HasColumnName("numBusinessSeats");

                entity.Property(e => e.NumEconomySeats).HasColumnName("numEconomySeats");

                entity.Property(e => e.SchdDays)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("schdDays");

                entity.Property(e => e.StrtDate)
                    .HasColumnType("datetime")
                    .HasColumnName("strtDate");

                entity.Property(e => e.TicketFare).HasColumnName("ticketFare");

                entity.Property(e => e.ToPlace)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("toPlace");
            });

            modelBuilder.Entity<TblPassengerList>(entity =>
            {
                entity.HasKey(e => e.BookingId);

                entity.ToTable("tblPassengerList");

                entity.Property(e => e.BookingId)
                    .ValueGeneratedNever()
                    .HasColumnName("bookingID");

                entity.Property(e => e.PassngrAge).HasColumnName("passngrAge");

                entity.Property(e => e.PassngrGender)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PassngrName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("passngrName");

                entity.Property(e => e.PnrNo).HasColumnName("pnrNo");
            });

            modelBuilder.Entity<TblUserName>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("tblUserName");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("userId");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("createdOn");

                entity.Property(e => e.LastPwdChanged)
                    .HasColumnType("datetime")
                    .HasColumnName("lastPwdChanged");

                entity.Property(e => e.MailId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("mailID");

                entity.Property(e => e.PassWord)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("passWord");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
