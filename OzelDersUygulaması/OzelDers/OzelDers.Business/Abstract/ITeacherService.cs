using OzelDers.Entity.Concrete;
using OzelDers.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelDers.Business.Abstract
{
    public interface ITeacherService
    {
        Task<Teacher> GetByIdAsync(int id);
        Task<List<Teacher>> GetAllAsync();
        Task CreateAsync(Teacher teacher);
        void Update(Teacher teacher);
        void Delete(Teacher teacher);
        Task<List<Teacher>> GetHomePageTeachersAsync();
        Task<List<Teacher>> GetTeacherByBranchAsync(string branchurl);
        Task<List<Teacher>> GetTeacherWithAll(); // Teacherları branş ve öğrencisiyle getirecek.
        Task<Teacher> GetTeacherWithAll(int id);
        Task<Teacher> GetTeacherDetailsByUrlAsync(string url); // Öğretmen Detayları getirilecek
        Task<Teacher> GetTeacherDetailsByIdAsync(int id); // Öğretmen Detayları getirilecek

        Task CreateTeacherAsync(Teacher teacher, int[]? SelectedBranchId);
        Task CreateTeacherAsync(Teacher teacher);
        Task UpdateTeacherAsync(Teacher teacher, int[]? selectedBranchId, int[]? selectedStudentId);
        Task<List<Teacher>> GetSearchResultsAsync(string searchString);




    }
}
