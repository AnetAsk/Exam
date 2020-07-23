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

namespace University.WebAPI.ApplicationMediatr.FilingAnApplication
{
    public class FilingApplicationCommandHandler : IRequestHandler<FilingApplicationCommand, ApplicationDTO>
    {
        private readonly IUnitOfWork _context;
        private readonly ILogger<FilingApplicationCommandHandler> _logger;

        public FilingApplicationCommandHandler(ILogger<FilingApplicationCommandHandler> logger, IUnitOfWork context)
        {
            _logger = logger;
            _context = context;
        }

        public Task<ApplicationDTO> Handle(FilingApplicationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newApplication = new Application
                {
                    College = request.College,
                    IIN = request.IIN,
                    Score = request.Score,
                    ProfileFirst = request.ProfileFirst,
                    ProfileSecond = request.ProfileSecond
                };

                _context.Applications.Add(newApplication);
                _context.Save();

                return Task.FromResult(newApplication.Adapt<ApplicationDTO>());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
    }
}
