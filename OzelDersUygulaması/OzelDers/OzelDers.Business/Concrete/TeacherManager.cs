using OzelDers.Business.Abstract;
using OzelDers.Data.Abstract;
using OzelDers.Entity.Concrete;
using OzelDers.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelDers.Business.Concrete
{
    public class TeacherManager : ITeacherService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeacherManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(Teacher teacher)
        {
            await _unitOfWork.Teachers.CreateAsync(teacher);
            await _unitOfWork.SaveAsync();
        }

        public async Task CreateTeacherAsync(Teacher teacher, int[] SelectedBranchId)
        {
            await _unitOfWork.Teachers.CreateTeacherAsync(teacher, SelectedBranchId);
        }

        public async Task CreateTeacherAsync(Teacher teacher)
        {
            await _unitOfWork.Teachers.CreateTeacherAsync(teacher);
        }

        public void Delete(Teacher teacher)
        {
            _unitOfWork.Teachers.Delete(teacher);
            _unitOfWork.Save();
        }

        public async Task<List<Teacher>> GetAllAsync()
        {
            return await _unitOfWork.Teachers.GetAllAsync();
        }

        public async Task<Teacher> GetByIdAsync(int id)
        {
            return await _unitOfWork.Teachers.GetByIdAsync(id);

        }

        public async Task<List<Teacher>> GetHomePageTeachersAsync()
        {
            return await _unitOfWork.Teachers.GetHomePageTeachersAsync();
        }

        public async Task<List<Teacher>> GetSearchResultsAsync(string searchString)
        {
            return await _unitOfWork.Teachers.GetSearchResultsAsync(searchString);
        }

        public async Task<List<Teacher>> GetTeacherByBranchAsync(string branchurl)
        {
            return await _unitOfWork.Teachers.GetTeacherByBranchAsync(branchurl);
        }

        public async Task<Teacher> GetTeacherDetailsByIdAsync(int id)
        {
            return await _unitOfWork.Teachers.GetTeacherDetailsByIdAsync(id);
        }

        public async Task<Teacher> GetTeacherDetailsByUrlAsync(string url)
        {
            return await _unitOfWork.Teachers.GetTeacherDetailsByUrlAsync(url);
        }

        public async Task<List<Teacher>> GetTeacherWithAll()
        {
            return await _unitOfWork.Teachers.GetTeacherWithAll();
        }

        public async Task<Teacher> GetTeacherWithAll(int id)
        {
            return await _unitOfWork.Teachers.GetTeacherWithAll(id);
        }

        public void Update(Teacher teacher)
        {
           _unitOfWork.Teachers.Update(teacher);
            _unitOfWork.Save();
        }

        public async Task UpdateTeacherAsync(Teacher teacher, int[] selectedBranchId, int[] selectedStudentId)
        {
            await _unitOfWork.Teachers.UpdateTeacherAsync(teacher, selectedBranchId, selectedStudentId);
        }
    }
}
