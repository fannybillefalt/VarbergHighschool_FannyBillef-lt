using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VarbergHighschool_FannyBillefält.Models;

public partial class VarbergHighschoolContext : DbContext
{
    public VarbergHighschoolContext()
    {
    }

    public VarbergHighschoolContext(DbContextOptions<VarbergHighschoolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<ClassTeacher> ClassTeachers { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=VarbergHighschool;Integrated Security=true;Trust Server Certificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Classes__3214EC070B0AD97A");

            entity.Property(e => e.Classname)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ClassTeacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ClassTea__3214EC07B5AA7ABA");

            entity.HasOne(d => d.Class).WithMany(p => p.ClassTeachers)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__ClassTeac__Class__3A81B327");

            entity.HasOne(d => d.Staff).WithMany(p => p.ClassTeachers)
                .HasForeignKey(d => d.StaffId)
                .HasConstraintName("FK__ClassTeac__Staff__3B75D760");

            entity.HasOne(d => d.Subject).WithMany(p => p.ClassTeachers)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK__ClassTeac__Subje__3C69FB99");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC0729FCE2E5");

            entity.Property(e => e.DepartmentName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Grades__3214EC07F41184AD");

            entity.Property(e => e.Grade1)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Grade");

            entity.HasOne(d => d.Staff).WithMany(p => p.Grades)
                .HasForeignKey(d => d.StaffId)
                .HasConstraintName("FK__Grades__StaffId__37A5467C");

            entity.HasOne(d => d.Student).WithMany(p => p.Grades)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Grades__StudentI__36B12243");

            entity.HasOne(d => d.Subject).WithMany(p => p.Grades)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK__Grades__SubjectI__35BCFE0A");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Position__3214EC0716AA04DA");

            entity.Property(e => e.Position1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Position");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Staff__3214EC072E13AC91");

            entity.HasIndex(e => e.SocialSecurityNumber, "UQ__Staff__2EFDFD395937808D").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Staff__A9D105340F2B5017").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Firstname)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Lastname)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SocialSecurityNumber)
                .HasMaxLength(13)
                .IsUnicode(false);

            entity.HasOne(d => d.Department).WithMany(p => p.Staff)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__Staff__Departmen__2B3F6F97");

            entity.HasOne(d => d.Position).WithMany(p => p.Staff)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK__Staff__PositionI__2A4B4B5E");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC07DC46CA7E");

            entity.HasIndex(e => e.SocialSecurityNumber, "UQ__Students__2EFDFD393941C4D0").IsUnique();

            entity.Property(e => e.Firstname)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Lastname)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SocialSecurityNumber)
                .HasMaxLength(13)
                .IsUnicode(false);

            entity.HasOne(d => d.Class).WithMany(p => p.Students)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__Students__ClassI__32E0915F");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Subjects__3214EC074864123D");

            entity.Property(e => e.SubjectName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
