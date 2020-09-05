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

        public virtual DbSet<Customer> Customer { get; set; }
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
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerNo);

                entity.Property(e => e.CustomerNo).HasMaxLength(10);

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Customerid).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.InvoiceNo);

                entity.Property(e => e.InvoiceNo).HasMaxLength(10);

                entity.Property(e => e.CustomerNo)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.Invoiceid).ValueGeneratedOnAdd();

                entity.Property(e => e.PaymentDueDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.PaymentNo);

                entity.Property(e => e.PaymentNo).HasMaxLength(10);

                entity.Property(e => e.InvoiceNo)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.Paymentid).ValueGeneratedOnAdd();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
