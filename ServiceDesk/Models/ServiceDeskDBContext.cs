using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ServiceDesk
{
    public partial class ServiceDeskDBContext : DbContext
    {
        public ServiceDeskDBContext()
        {
        }

        public ServiceDeskDBContext(DbContextOptions<ServiceDeskDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookMarked> BookMarkeds { get; set; }
        public virtual DbSet<Resolution> Resolutions { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=ServiceDeskDB; Integrated Security=SSPI;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BookMarked>(entity =>
            {
                entity.ToTable("BookMarked");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.BookMarkedBy).HasMaxLength(50);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.BookMarked)
                    .HasForeignKey<BookMarked>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BookMarked__ID__36B12243");
            });

            modelBuilder.Entity<Resolution>(entity =>
            {
                entity.ToTable("Resolution");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.ClosedBy).HasMaxLength(50);

                entity.Property(e => e.Resolution1)
                    .HasColumnType("text")
                    .HasColumnName("Resolution");

                entity.Property(e => e.TicketName).HasMaxLength(50);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Resolution)
                    .HasForeignKey<Resolution>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Resolution__ID__3C69FB99");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Issue).HasColumnType("text");

                entity.Property(e => e.OpenedBy).HasMaxLength(50);

                entity.Property(e => e.TicketName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
