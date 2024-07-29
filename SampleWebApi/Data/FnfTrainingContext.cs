using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SampleWebApi.Data;

public partial class FnfTrainingContext : DbContext
{
    public FnfTrainingContext()
    {
    }

    public FnfTrainingContext(DbContextOptions<FnfTrainingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<StockTable> StockTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=FNFIDVPRE20529\\SQLSERVER; Database=FnfTraining; Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<StockTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StockTab__3214EC07499B6461");

            entity.ToTable("StockTable");

            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
