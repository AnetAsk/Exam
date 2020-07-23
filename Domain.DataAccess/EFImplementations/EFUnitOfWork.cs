using Domain.DataAccess.Services;
using Domain.Model;

namespace Domain.DataAccess.EFImplementations
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public IRepository<Application> Applications { get; set; }

        public EFUnitOfWork(ApplicationContext context, IRepository<Application> applications)
        {
            _context = context;
            Applications = applications;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            if (_context.Database.CurrentTransaction != null)
            {
                _context.Database.CurrentTransaction.Commit();
            }
        }

        public void Rollback()
        {
            if (_context.Database.CurrentTransaction != null)
            {
                _context.Database.CurrentTransaction.Rollback();
            }
        }
    }
}
