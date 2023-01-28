using OzelDers.Data.Concrete;
using OzelDers.Entity.Concrete;
using OzelDers.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelDers.Data.Abstract
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
        Task<List<Teacher>> GetByIdBranch(int id);
        Task<List<Teacher>> GetHomePageTeachersAsync();
        Task<List<Teacher>> GetTeacherByBranchAsync(string branchurl);
        Task<List<Teacher>> GetTeacherWithAll();
        Task<Teacher> GetTeacherWithAll(int id);
        Task<Teacher> GetTeacherDetailsByUrlAsync(string url);
        Task<Teacher> GetTeacherDetailsByIdAsync(int id);

        Task CreateTeacherAsync(Teacher teacher, int[]? SelectedBranchId);
        Task UpdateTeacherAsync(Teacher teacher, int[]? selectedBranchId, int[]? selectedStudentId);
        Task<List<Teacher>> GetSearchResultsAsync(string searchString);
        Task CreateTeacherAsync(Teacher teacher);
    }
}
