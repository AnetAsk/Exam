using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using University.DataAccess.Interfaces;
using University.Domain;
using University.DTOs;

namespace University.WebAPI.ApplicationMediatr.EditApplication
{
    public class EditApplicationRequestHandler : IRequestHandler<EditApplicationRequest, ApplicationDTO>
    {
        private readonly IUnitOfWork _context;
        private readonly ILogger<EditApplicationRequestHandler> _logger;

        public EditApplicationRequestHandler(ILogger<EditApplicationRequestHandler> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _context = unitOfWork;
        }
        public Task<ApplicationDTO> Handle(EditApplicationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var editApplication = new Application
                {
                    Id = request.Id,
                    College = request.College,
                    IIN = request.IIN,
                    Score = request.Score,
                    ProfileFirst = request.ProfileFirst,
                    ProfileSecond = request.ProfileSecond
                };

                _context.Applications.Edit(editApplication);
                _context.Save();

                return Task.FromResult(editApplication.Adapt<ApplicationDTO>());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
    }
}
