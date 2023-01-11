using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OzelDers.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelDers.Data.Config
{
    public class StudentAndTeacherConfig : IEntityTypeConfiguration<StudentAndTeacher>
    {
        public void Configure(EntityTypeBuilder<StudentAndTeacher> builder)
        {
            builder.HasKey(st => new { st.StudentId, st.TeacherId });

            builder.HasData(
                new StudentAndTeacher { StudentId = 1, TeacherId = 1 },
                new StudentAndTeacher { StudentId = 2, TeacherId = 2 },
                new StudentAndTeacher { StudentId = 3, TeacherId = 2 },
                new StudentAndTeacher { StudentId = 4, TeacherId = 3 },
                new StudentAndTeacher { StudentId = 5, TeacherId = 4 },
                new StudentAndTeacher { StudentId = 6, TeacherId = 5 },
                new StudentAndTeacher { StudentId = 7, TeacherId = 6 },
                new StudentAndTeacher { StudentId = 8, TeacherId = 1 },
                new StudentAndTeacher { StudentId = 9, TeacherId = 3 }
                );
        }
    }
}
