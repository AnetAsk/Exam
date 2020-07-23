using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Model;
using Domain.DataAccess.Services;

namespace Domain.DataAccess.EFImplementations
{
    public class ApplicationRepository : IRepository<Application>
    {
        private readonly ApplicationContext _context;
        private ILogger<ApplicationRepository> _logger;

        public ApplicationRepository(ILogger<ApplicationRepository> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        public bool Add(Application entity)
        {
            try
            {
                _context.Applications.Add(entity);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public bool Delete(Application entity)
        {
            try
            {
                _context.Applications.Remove(entity);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public bool Edit(Application entity)
        {
            try
            {
                _context.Applications.Update(entity);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public Application Get(Guid id)
        {
            var application = _context.Applications.Find(id);
            if (application == null) return null;

            return application;
        }

        public IList<Application> GetAll()
        {
            return _context.Applications.ToList();
        }
    }
}
