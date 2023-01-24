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

        public async Task CreateTeacherAsync(Teacher teacher, int[] SelectedBranchId)
        {
            await OzelDersContext.Teachers.AddAsync(teacher);
            await OzelDersContext.SaveChangesAsync();
            teacher.TeacherAndBranches = SelectedBranchId
                .Select(brId => new TeacherAndBranch
                {
                    TeacherId = teacher.Id,
                    BranchId = brId
                }).ToList();
            await OzelDersContext.SaveChangesAsync();
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

        public async Task<List<Teacher>> GetSearchResultsAsync(string searchString)
        {
            searchString = searchString.ToLower();
            var result = OzelDersContext.Teachers.Include(t => t.TeacherAndBranches).ThenInclude(tb => tb.Branch).AsQueryable();
            return await result.Where(p => p.FirstName.ToLower().Contains(searchString) || p.Description.ToLower().Contains(searchString))
              .ToListAsync();

        }

        public async Task<List<Teacher>> GetTeacherByBranchAsync(string branchurl)
        {
            var teachers = OzelDersContext.Teachers.AsQueryable();
            if (branchurl != null)
            {
                teachers = teachers
                    .Include(p => p.TeacherAndBranches)
                    .ThenInclude(pc => pc.Branch)
                    .Where(p => p.TeacherAndBranches.Any(pc => pc.Branch.Url == branchurl));
            }
            return await teachers.ToListAsync();
        }

        public async Task<Teacher> GetTeacherDetailsByUrlAsync(string url)
        {
            return await OzelDersContext
               .Teachers
               .Where(t=>t.Url==url)
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

        public async Task<Teacher> GetTeacherWithAll(int id)
        {
            return await OzelDersContext
             .Teachers
             .Where(t => t.Id == id)
             .Include(t => t.TeacherAndBranches)
             .ThenInclude(tab => tab.Branch)
             .Include(t => t.StudentAndTeachers)
             .ThenInclude(tas => tas.Student)
             .FirstOrDefaultAsync();
        }

        public async Task UpdateTeacherAsync(Teacher teacher, int[] selectedBranchId, int[] selectedStudentId)
        {
            Teacher newTeacher = await OzelDersContext
                 .Teachers
                 .Include(p => p.TeacherAndBranches)                
                 .FirstOrDefaultAsync(p => p.Id == teacher.Id);
            newTeacher.TeacherAndBranches = selectedBranchId
                .Select(brId => new TeacherAndBranch
                {
                    TeacherId = newTeacher.Id,
                    BranchId = brId
                }).ToList();

             await OzelDersContext
                 .Teachers
                 .Include(p => p.StudentAndTeachers)
                 .FirstOrDefaultAsync(p => p.Id == teacher.Id);
            newTeacher.StudentAndTeachers = selectedStudentId
                .Select(stId => new StudentAndTeacher
                {
                    TeacherId = newTeacher.Id,
                    StudentId = stId
                }).ToList();
            OzelDersContext.Update(newTeacher);
            await OzelDersContext.SaveChangesAsync();
        }
    }
}
