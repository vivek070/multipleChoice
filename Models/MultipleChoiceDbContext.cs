using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace multipleChoice.Models;

public partial class MultipleChoiceDbContext : DbContext
{
    public MultipleChoiceDbContext()
    {
    }

    public MultipleChoiceDbContext(DbContextOptions<MultipleChoiceDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MasteQuestion> MasteQuestions { get; set; }

    public virtual DbSet<VquestionView> VquestionViews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-AD2SV99;Initial Catalog=multipleChoiceDB;Persist Security Info=True;User ID=sa;Password=12345678;Trust Server Certificate=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MasteQuestion>(entity =>
        {
            entity.HasKey(e => e.QuestionIdpk);

            entity.ToTable("masteQuestion");

            entity.Property(e => e.QuestionIdpk).HasColumnName("QuestionIDPK");
            entity.Property(e => e.CreatDt)
                .HasColumnType("datetime")
                .HasColumnName("creatDT");
            entity.Property(e => e.CreatIdfk).HasColumnName("creatIDFK");
            entity.Property(e => e.ModiDt)
                .HasColumnType("datetime")
                .HasColumnName("modiDT");
            entity.Property(e => e.ModiIdfk).HasColumnName("modiIDFK");
            entity.Property(e => e.QuestionCorrectOption).HasMaxLength(50);
            entity.Property(e => e.QuestionLanguage).HasMaxLength(50);
            entity.Property(e => e.QuestionOptionA).HasMaxLength(50);
            entity.Property(e => e.QuestionOptionB).HasMaxLength(50);
            entity.Property(e => e.QuestionOptionC).HasMaxLength(50);
            entity.Property(e => e.QuestionOptionD).HasMaxLength(50);
            entity.Property(e => e.QuestionText).HasMaxLength(500);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("A")
                .HasColumnName("status");
        });

        modelBuilder.Entity<VquestionView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VquestionView");

            entity.Property(e => e.QuestionCorrectOption).HasMaxLength(50);
            entity.Property(e => e.QuestionLanguage).HasMaxLength(50);
            entity.Property(e => e.QuestionOptionA).HasMaxLength(50);
            entity.Property(e => e.QuestionOptionB).HasMaxLength(50);
            entity.Property(e => e.QuestionOptionC).HasMaxLength(50);
            entity.Property(e => e.QuestionOptionD).HasMaxLength(50);
            entity.Property(e => e.QuestionText).HasMaxLength(500);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
