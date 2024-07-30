using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedCare.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseApiController : ControllerBase
{
    private ISender Mediator = null!;

    protected ISender _mediator => Mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}
