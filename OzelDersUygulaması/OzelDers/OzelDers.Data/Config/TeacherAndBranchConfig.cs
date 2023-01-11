using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OzelDers.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelDers.Data.Config
{
    public class TeacherAndBranchConfig : IEntityTypeConfiguration<TeacherAndBranch>
    {
        public void Configure(EntityTypeBuilder<TeacherAndBranch> builder)
        {
            builder.HasKey(st => new { st.TeacherId, st.BranchId });

            builder.HasData(
                new TeacherAndBranch {  TeacherId = 1, BranchId = 5, },
                new TeacherAndBranch {  TeacherId = 2, BranchId = 2, },
                new TeacherAndBranch {  TeacherId = 3, BranchId = 1, },
                new TeacherAndBranch {  TeacherId = 4, BranchId = 3, },
                new TeacherAndBranch {  TeacherId = 5, BranchId = 9, },
                new TeacherAndBranch {  TeacherId = 6, BranchId = 6, },
                new TeacherAndBranch {  TeacherId = 7, BranchId = 8, },
                new TeacherAndBranch {  TeacherId = 7, BranchId = 10, },
                new TeacherAndBranch {  TeacherId = 2, BranchId = 8, }
                
                );
        }
    }
}
