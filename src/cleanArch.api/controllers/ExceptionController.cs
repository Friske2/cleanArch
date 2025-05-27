using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using cleanArch.Application.Exceptions;
namespace cleanArch.api.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExceptionController : ControllerBase
    {
        [HttpGet("badrequest")]
        public IActionResult BadRequestExample()
        {
            throw new BadRequestException("This is a bad request example.");
        }

        [HttpGet("notfound")]
        public IActionResult NotFoundExample()
        {
            throw new NotFoundException("This resource was not found.");
        }

        [HttpGet("internalservererror")]
        public IActionResult InternalServerErrorExample()
        {
            throw new InternalServerErrorException("An unexpected error occurred.");
        }
    }
}
