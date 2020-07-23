using Mapster;
using MediatR;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using University.DataAccess.Interfaces;
using University.DTOs;

namespace University.WebAPI.ApplicationMediatr.GetById
{
    public class GetByIdRequestHandler : IRequestHandler<GetByIdRequest, ApplicationDTO>
    {
        private readonly IUnitOfWork _context;
        private readonly ILogger<GetByIdRequestHandler> _logger;

        public GetByIdRequestHandler(ILogger<GetByIdRequestHandler> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _context = unitOfWork;
        }

        public Task<ApplicationDTO> Handle(GetByIdRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var application = _context.Applications.Get(request.Id);
                if (application == null) return Task.FromResult(new ApplicationDTO());

                return Task.FromResult(application.Adapt<ApplicationDTO>());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
    }
}
