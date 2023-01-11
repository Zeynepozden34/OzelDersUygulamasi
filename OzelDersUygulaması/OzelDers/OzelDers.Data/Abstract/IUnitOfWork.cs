using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelDers.Data.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository Students { get; }
        ITeacherRepository Teachers { get; }
        IBranchRepository Branchs { get; }
        Task SaveAsync();
        void Save();
    }
}
