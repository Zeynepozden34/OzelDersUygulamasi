using Microsoft.EntityFrameworkCore;
using OzelDers.Data.Abstract;
using OzelDers.Data.Concrete.EfCore.Contexts;
using OzelDers.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelDers.Data.Concrete.EfCore.Repositories
{
    public class EfCoreStudentRepository : EfCoreGenericRepository<Student>, IStudentRepository
    {
        public EfCoreStudentRepository(OzelDersContext context) : base(context)
        {

        }
        private OzelDersContext OzelDersContext
        {
            get { return _context as OzelDersContext; }
        }

        public async Task<List<Student>> GetStudentWithTeacher()
        {
            return await OzelDersContext
                .Students
                .Include(s => s.StudentAndTeachers)
                .ThenInclude(st => st.Teacher)
                .ToListAsync();
        }

        public async Task<Student> GetStudentDetailsByUrlAsync(string url)
        {
            return await OzelDersContext
              .Students
              .Where(s => s.Url == url)
              .Include(s => s.StudentAndTeachers)
              .ThenInclude(st => st.Teacher)
              .FirstOrDefaultAsync();

        }

        public async Task CreateStudentAsync(Student student, int[]? teacher)
        {
            await OzelDersContext.Students.AddAsync(student);
            await OzelDersContext.SaveChangesAsync();
            student.StudentAndTeachers = teacher
                .Select(tecId => new StudentAndTeacher
                {
                    StudentId=student.Id,
                    TeacherId=tecId
                }).ToList();
            await OzelDersContext.SaveChangesAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await OzelDersContext
              .Students
              .Where(s=>s.Id==id)
              .Include(s => s.StudentAndTeachers)
              .ThenInclude(st => st.Teacher)
              .FirstOrDefaultAsync();
        }

        public async Task<Student> GetStudentWithTeacher(int id)
        {
            return await OzelDersContext
               .Students
               .Where(s=>s.Id==id)
               .Include(s => s.StudentAndTeachers)
               .ThenInclude(st => st.Teacher)
               .FirstOrDefaultAsync();
        }

        public async Task UpdateStudentAsync(Student student, int[] selectedTeacherId)
        {
            Student newStudent = await OzelDersContext
                 .Students
                 .Include(p => p.StudentAndTeachers)
                 .FirstOrDefaultAsync(p => p.Id == student.Id);
            newStudent.StudentAndTeachers = selectedTeacherId
                .Select(tchId => new StudentAndTeacher
                {
                    StudentId = newStudent.Id,
                    TeacherId = tchId
                }).ToList();
           
            OzelDersContext.Update(newStudent);
            await OzelDersContext.SaveChangesAsync();
        }
    }
}
