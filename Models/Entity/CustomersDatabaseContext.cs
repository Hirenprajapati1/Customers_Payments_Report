using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Customers_Payments_Report.Models.Entity
{
    public partial class CustomersDatabaseContext : DbContext
    {
        public CustomersDatabaseContext()
        {
        }

        public CustomersDatabaseContext(DbContextOptions<CustomersDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<AutoIncrimentNo> AutoIncrimentNo { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<GeneralSettings> GeneralSettings { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CustomersDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK__tmp_ms_x__737584F76C95F0CB");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.ContactNo).HasMaxLength(15);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("Created_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("FirstName ")
                    .HasMaxLength(50);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("Modify_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AutoIncrimentNo>(entity =>
            {
                entity.ToTable("Auto Incriment No");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LastCustomerNo)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.LastInvoiceNo)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.LastPaymentNo)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerNo);

                entity.Property(e => e.CustomerNo).HasMaxLength(10);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("Created_by")
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("Created_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifyBy)
                    .HasColumnName("Modify_by")
                    .HasMaxLength(50);

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("Modify_date")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<GeneralSettings>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.InvoiceNo);

                entity.Property(e => e.InvoiceNo).HasMaxLength(10);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("Created_by")
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("Created_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustomerNo)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.InvoiceAmount).HasColumnType("money");

                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.ModifyBy)
                    .HasColumnName("Modify_by")
                    .HasMaxLength(50);

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("Modify_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.PaymentDueDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.PaymentNo);

                entity.Property(e => e.PaymentNo).HasMaxLength(10);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("Created_by")
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("Created_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.InvoiceNo)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.ModifyBy)
                    .HasColumnName("Modify_by")
                    .HasMaxLength(50);

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("Modify_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.PaymentAmount).HasColumnType("money");

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
