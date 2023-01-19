using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OzelDers.Data.Config;
using OzelDers.Data.Extension;
using OzelDers.Entity.Concrete;
using OzelDers.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelDers.Data.Concrete.EfCore.Contexts
{
    public class OzelDersContext : IdentityDbContext<User, Role, string>
    {
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentAndTeacher> StudentAndTeachers { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherAndBranch> TeacherAndBranches { get; set; }

        public OzelDersContext(DbContextOptions<OzelDersContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedData();
            modelBuilder.ApplyConfiguration(new StudentConfig());
            modelBuilder.ApplyConfiguration(new TeacherConfig());
            modelBuilder.ApplyConfiguration(new BranchConfig());
            modelBuilder.ApplyConfiguration(new StudentAndTeacherConfig());
            modelBuilder.ApplyConfiguration(new TeacherAndBranchConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
