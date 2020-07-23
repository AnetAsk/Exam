using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Exam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly ILogger<ApplicationController> _logger;
        private readonly IMediator _mediator;

        public ApplicationController(ILogger<ApplicationController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetApplicationById(int id)
        {
            var request = new GetByIdRequest(id);
            var response = await _mediator.Send(request);

            return Ok(response);
        }
        
        [HttpPost]
        public async Task<IActionResult> FilingAnApplication(ApplicationDTO applicationDTO)
        {
            var request = new FilingApplicationCommand(applicationDTO);
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditApplication(int id, ApplicationDTO applicationDTO)
        {
            var request = new EditApplicationRequest(id, applicationDTO);
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplication(int id)
        {
            var request = new DeleteApplicationRequest(id);
            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
