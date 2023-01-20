using OzelDers.Business.Abstract;
using OzelDers.Data.Abstract;
using OzelDers.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelDers.Business.Concrete
{
    public class StudentManager : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(Student student)
        {
            await _unitOfWork.Students.CreateAsync(student);
            await _unitOfWork.SaveAsync();
        }

        public async  Task CreateStudentAsync(Student student, int[]? teacher)
        {
            await _unitOfWork.Students.CreateStudentAsync(student, teacher);
        }

        public void Delete(Student student)
        {
             _unitOfWork.Students.Delete(student);
            _unitOfWork.SaveAsync();
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _unitOfWork.Students.GetAllAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _unitOfWork.Students.GetByIdAsync(id);
        }

        public async Task<Student> GetStudentDetailsByUrlAsync(string url)
        {
            return await _unitOfWork.Students.GetStudentDetailsByUrlAsync(url);
        }

        public async Task<List<Student>> GetStudentWithTeacher()
        {
            return await _unitOfWork.Students.GetStudentWithTeacher();
        }

        public void Update(Student student)
        {
            _unitOfWork.Students.Update(student);
            _unitOfWork.SaveAsync();
        }
    }
}
