using System;
using CoreAuth.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreAuth.API
{
    public partial class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options):base(options)
        {

        }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Department> Department { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Employees>(entity =>
        //    {
        //        entity.Property(e => e.Id).HasColumnName("ID");

        //        entity.Property(e => e.DepartmentName)
        //            .HasMaxLength(50)
        //            .IsUnicode(false);

        //        entity.Property(e => e.FirstName).HasMaxLength(50);

        //        entity.Property(e => e.Gender).HasMaxLength(50);

        //        entity.Property(e => e.LastName).HasMaxLength(50);
        //    });

        //    OnModelCreatingPartial(modelBuilder);
        //}

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
