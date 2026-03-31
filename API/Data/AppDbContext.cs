using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class AppDbContext(DbContextOptions options) : IdentityDbContext<AppUser>(options)
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Parents> Parents { get; set; }

    public DbSet<Session> Sessions { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<Section> Sections { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>()
            .HasData(
                new IdentityRole { Id = "member-id", Name = "Member", NormalizedName = "MEMBER" },
                new IdentityRole { Id = "accountant-id", Name = "Accountant", NormalizedName = "ACCOUNTANT" },
                new IdentityRole { Id = "admin-id", Name = "Admin", NormalizedName = "ADMIN" }
            );

        //  Parents → Students (1-to-Many)
        modelBuilder.Entity<Student>()
            .HasOne(s => s.Parents)
            .WithMany(p => p.Students)
            .HasForeignKey(s => s.ParentsId)
            .OnDelete(DeleteBehavior.Restrict);

        //  Student → Enrollment
        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Student)
            .WithMany(s => s.Enrollments)
            .HasForeignKey(e => e.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        //  Session → Enrollment
        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Session)
            .WithMany(s => s.Enrollments)
            .HasForeignKey(e => e.SessionId)
            .OnDelete(DeleteBehavior.Restrict);

        //  Class → Enrollment
        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Class)
            .WithMany()
            .HasForeignKey(e => e.ClassId)
            .OnDelete(DeleteBehavior.Restrict);

        //  Section → Enrollment
        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Section)
            .WithMany(s => s.Enrollments)
            .HasForeignKey(e => e.SectionId)
            .OnDelete(DeleteBehavior.Restrict);

        //  Section → Class
        modelBuilder.Entity<Section>()
            .HasOne(s => s.Class)
            .WithMany(c => c.Sections)
            .HasForeignKey(s => s.ClassId)
            .OnDelete(DeleteBehavior.Cascade);

        //  UNIQUE: Prevent duplicate enrollment
        modelBuilder.Entity<Enrollment>()
            .HasIndex(e => new { e.StudentId, e.SessionId })
            .IsUnique();

        //  UNIQUE: Prevent duplicate parents (Father CNIC)
        modelBuilder.Entity<Parents>()
            .HasIndex(p => p.FatherCnic)
            .IsUnique();
        }
}

