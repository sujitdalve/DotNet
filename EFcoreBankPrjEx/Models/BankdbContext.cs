using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFcoreBankPrjEx.Models;

public partial class BankdbContext : DbContext
{
    public BankdbContext()
    {
    }

    public BankdbContext(DbContextOptions<BankdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Sbaccount> Sbaccounts { get; set; }

    public virtual DbSet<Sbtransaction> Sbtransactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-P05JP208\\SQLEXPRESS;Database=Bankdb;Trusted_Connection=True; encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sbaccount>(entity =>
        {
            entity.HasKey(e => e.AccNo).HasName("PK__SBAccoun__91CBCB536F91552B");

            entity.ToTable("SBAccount");

            entity.Property(e => e.AccNo).ValueGeneratedNever();
            entity.Property(e => e.Caddress)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CAddress");
            entity.Property(e => e.Cname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CName");
        });

        modelBuilder.Entity<Sbtransaction>(entity =>
        {
            entity.HasKey(e => e.Tid).HasName("PK__SBTransa__C456D749F17A1D16");

            entity.ToTable("SBTransaction");

            entity.Property(e => e.Tid)
                .ValueGeneratedNever()
                .HasColumnName("TId");
            entity.Property(e => e.Tdate)
                .HasColumnType("datetime")
                .HasColumnName("TDate");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.AccNoNavigation).WithMany(p => p.Sbtransactions)
                .HasForeignKey(d => d.AccNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SBTransac__AccNo__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
