using System.Net;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{
    protected ActionResult HandleException(Exception e)
    {
        HttpStatusCode httpStatusCode;
        string message;
        switch (e)
        {
            case ArgumentException argumentException:
                httpStatusCode = HttpStatusCode.BadRequest;
                message = argumentException.Message;
                break;
            case Exception exception:
                httpStatusCode = HttpStatusCode.NotAcceptable;
                message = exception.Message;
                break;
            default:
                httpStatusCode = HttpStatusCode.InternalServerError;
                message = "An unexpected error has ocurred";
                break;
        }
        return StatusCode((int)httpStatusCode, new { Error = message });
    }
}