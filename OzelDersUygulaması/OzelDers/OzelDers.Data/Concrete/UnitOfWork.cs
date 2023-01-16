using OzelDers.Data.Abstract;
using OzelDers.Data.Concrete.EfCore.Contexts;
using OzelDers.Data.Concrete.EfCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelDers.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OzelDersContext _context;

        public UnitOfWork(OzelDersContext context)
        {
            _context = context;
        }

        private EfCoreBranchRepository _branchRepository;
        private EfCoreStudentRepository _studentRepository;
        private EfCoreTeacherRepository _teacherRepository;

        public IStudentRepository Students => _studentRepository = _studentRepository ?? new EfCoreStudentRepository(_context);

        public ITeacherRepository Teachers => _teacherRepository= _teacherRepository ?? new EfCoreTeacherRepository(_context);

        public IBranchRepository Branchs => _branchRepository = _branchRepository?? new EfCoreBranchRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
