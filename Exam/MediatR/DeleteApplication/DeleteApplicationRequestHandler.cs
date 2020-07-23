using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using University.DataAccess.Interfaces;
using University.DTOs;

namespace University.WebAPI.ApplicationMediatr.DeleteApplication
{
    public class DeleteApplicationRequestHandler : IRequestHandler<DeleteApplicationRequest, string>
    {
        private readonly IUnitOfWork _context;
        private readonly ILogger<DeleteApplicationRequestHandler> _logger;

        public DeleteApplicationRequestHandler(ILogger<DeleteApplicationRequestHandler> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _context = unitOfWork;
        }

        public Task<string> Handle(DeleteApplicationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var application = _context.Applications.Get(request.Id);
                _context.Applications.Delete(application);
                _context.Save();

                return Task.FromResult(HttpStatusCode.OK.ToString());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
    }
}
