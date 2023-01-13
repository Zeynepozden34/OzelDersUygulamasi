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
    public class EfCoreTeacherRepository : EfCoreGenericRepository<Teacher>, ITeacherRepository
    {
        public EfCoreTeacherRepository(OzelDersContext context) : base(context)
        {
        }
        private OzelDersContext OzelDersContext
        {
            get { return _context as OzelDersContext; }
        }
        public async Task<List<Teacher>> GetByIdBranch(int id)
        {
            return await OzelDersContext
                 .Teachers
                 .Where(t => t.Id==id)
                 .ToListAsync();
        }

        public async Task<List<Teacher>> GetHomePageTeachersAsync()
        {
            return await OzelDersContext
                .Teachers
                .Include(t=>t.TeacherAndBranches)
                .ThenInclude(tab=>tab.Branch)
                .ToListAsync();
        }

        public async Task<List<Teacher>> GetTeacherByBranchAsync(string branch)
        {
            var teachers = OzelDersContext.Teachers.AsQueryable();
            if (branch != null)
            {
                teachers = teachers
                    .Include(p => p.TeacherAndBranches)
                    .ThenInclude(pc => pc.Branch)
                    .Where(p => p.TeacherAndBranches.Any(pc => pc.Branch.Url == branch));
            }
            return await teachers.ToListAsync();
        }

        public async Task<Teacher> GetTeacherDetailsByUrlAsync(string url)
        {
            return await OzelDersContext
               .Teachers
               .Include(t => t.TeacherAndBranches)
               .ThenInclude(tab => tab.Branch)
               .Include(t => t.StudentAndTeachers)
               .ThenInclude(tas => tas.Student)
               .FirstOrDefaultAsync();
        }

        public async  Task<List<Teacher>> GetTeacherWithAll()
        {
            return await OzelDersContext
                .Teachers
                .Include(t => t.TeacherAndBranches)
                .ThenInclude(tab => tab.Branch)
                .Include(t=>t.StudentAndTeachers)
                .ThenInclude(tas=>tas.Student)
                .ToListAsync();
        }
    }
}
