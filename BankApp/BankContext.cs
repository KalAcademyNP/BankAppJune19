using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    public class BankContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:bankuikalappdbserver.database.windows.net,1433;Initial Catalog=BankUIkal2App_db;Persist Security Info=False;User ID=kaladmin;Password=P@ssw0rd!!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(e =>
            {
                e.HasKey(a => a.AccountNumber)
                .HasName("PK_Accounts");

                e.ToTable("Accounts");

                e.Property(a => a.AccountNumber)
                    .ValueGeneratedOnAdd();

                e.Property(a => a.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(100);

                e.Property(a => a.AccountType)
                    .IsRequired();
            });

            modelBuilder.Entity<Transaction>(e =>
            {
                e.ToTable("Transactions");

                e.HasKey(t => t.TransactionId)
                    .HasName("PK_Transactions");

                e.Property(t => t.TransactionId)
                    .ValueGeneratedOnAdd();

                e.Property(t => t.Amount)
                    .IsRequired();

                e.HasOne(t => t.Account)
                    .WithMany()
                    .HasForeignKey(t => t.AccountNumber);

            });
        }

    }
}
