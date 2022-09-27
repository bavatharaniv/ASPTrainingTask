using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.Model
{
    public class RestDbContext :DbContext
    {
        #region Constructor
        public RestDbContext(DbContextOptions options) : base(options)
        {
        }
        #endregion

        public DbSet<Skill> Skills { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<SkillMap> Skillmaps { get; set; }

        #region Configuration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureModels(modelBuilder);

        }
        #endregion
        private static void ConfigureModels(ModelBuilder modelBuilder)
        {
            #region Entity: Skills
            modelBuilder.Entity<Skill>().ToTable("Skills");
            modelBuilder.Entity<Skill>().Property(x => x.SkillName).IsRequired().HasMaxLength(30);
            #endregion

            #region Entity: Employee
            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<Employee>().Property(x => x.EmpName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Employee>().Property(x => x.Status).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Employee>().Property(x => x.Manager).HasMaxLength(30);
            modelBuilder.Entity<Employee>().Property(x => x.WFManager).HasMaxLength(30);
            modelBuilder.Entity<Employee>().Property(x => x.Email);
            modelBuilder.Entity<Employee>().Property(x => x.Lockstatus).HasMaxLength(30);
            modelBuilder.Entity<Employee>().Property(x => x.Experience).HasColumnType("decimal(5,0)");
            modelBuilder.Entity<Employee>().Property(x => x.ProfileId).HasColumnType("decimal(5,0)");
            #endregion

            #region Entity: SkillMap
            modelBuilder.Entity<SkillMap>().ToTable("Skillmaps");
            modelBuilder.Entity<SkillMap>().HasKey(c => new { c.EmployeeId, c.SkillId });
            modelBuilder.Entity<SkillMap>().HasOne(a => a.Employee).WithMany(b => b.SkillMap).HasForeignKey(c => c.EmployeeId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<SkillMap>().HasOne(a => a.Skills).WithMany(b => b.SkillMap).HasForeignKey(c => c.SkillId).OnDelete(DeleteBehavior.NoAction);
            #endregion
        }
        public DbSet<APIRest.Model.Employeeswithskills> Employeeswithskills { get; set; }
    }
}
