using Domain.Model;

namespace Domain.DataAccess.Services
{
    public interface IUnitOfWork
    {
        IRepository<Application> Applications { get; set; }

        void Save();
        void Commit();
        void BeginTransaction();
        void Rollback();
    }
}
