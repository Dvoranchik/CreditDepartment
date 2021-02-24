using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Configuration;
#nullable disable

namespace CreditDepartment.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<Credit> Credits { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<LogonAudit> LogonAudits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseOracle(ConfigurationManager.ConnectionStrings["BankDatabase"].ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("DAN")
                .HasAnnotation("Relational:Collation", "USING_NLS_COMP");

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("CLIENT");

                entity.Property(e => e.ClientId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CLIENT_ID");

                entity.Property(e => e.ClientAddress)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("CLIENT_ADDRESS");

                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("CLIENT_NAME");

                entity.Property(e => e.ClientPasswordNumber)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CLIENT_PASSWORD_NUMBER");

                entity.Property(e => e.ClientPayment)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CLIENT_PAYMENT");

                entity.Property(e => e.ClientPlaceOfWork)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("CLIENT_PLACE_OF_WORK");

                entity.Property(e => e.ClientTelephone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CLIENT_TELEPHONE");
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.ToTable("CONTRACT");

                entity.Property(e => e.ContractId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CONTRACT_ID");

                entity.Property(e => e.ClientId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CLIENT_ID");

                entity.Property(e => e.ContractData)
                    .HasColumnType("DATE")
                    .HasColumnName("CONTRACT_DATA");

                entity.Property(e => e.ContractType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_TYPE");

                entity.Property(e => e.CreditId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CREDIT_ID");

                entity.Property(e => e.EmployeeId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("EMPLOYEE_ID");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("CONTRACT_CLIENT_FK");

                entity.HasOne(d => d.Credit)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.CreditId)
                    .HasConstraintName("CONTRACT_CREDIT_FK");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("CONTRACT_EMPLOYEE_FK");
            });

            modelBuilder.Entity<Credit>(entity =>
            {
                entity.ToTable("CREDIT");

                entity.Property(e => e.CreditId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CREDIT_ID");

                entity.Property(e => e.CreditAdditionalServices)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CREDIT_ADDITIONAL_SERVICES");

                entity.Property(e => e.CreditLoanProgram)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CREDIT_LOAN_PROGRAM");

                entity.Property(e => e.CreditProcent)
                    .HasColumnType("NUMBER(3,2)")
                    .HasColumnName("CREDIT_PROCENT");

                entity.Property(e => e.CreditType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CREDIT_TYPE");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("EMPLOYEE");

                entity.Property(e => e.EmployeeId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYEE_NAME");

                entity.Property(e => e.EmployeePost)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYEE_POST");
            });

            modelBuilder.Entity<LogonAudit>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("LOGON_AUDIT");

                entity.Property(e => e.Host)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("HOST");

                entity.Property(e => e.LogoffTime)
                    .HasColumnType("DATE")
                    .HasColumnName("LOGOFF_TIME");

                entity.Property(e => e.LogonTime)
                    .HasColumnType("DATE")
                    .HasColumnName("LOGON_TIME");

                entity.Property(e => e.SessId)
                    .HasPrecision(10)
                    .HasColumnName("SESS_ID");

                entity.Property(e => e.UserId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USER_ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
