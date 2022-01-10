using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using WebApplicationExceptions.Classes;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationExceptions
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        // GET: api/<ValuesController>
        [HttpGet("{id}")]
        public OkObjectResult Get(int id)
        {
            var claims = ClaimsOperations.GetAllClaims(id);
            //throw new AccessViolationException("Violation Exception while accessing the resource.");
            _logger.LogInformation($"Returning {claims.Count} claims");
            return Ok(claims);
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (AccessViolationException accessViolationException)
            {
                _logger.LogError($"A new violation exception has been thrown: {accessViolationException}");
                await HandleExceptionAsync(httpContext, accessViolationException);
            }
            catch (Exception exception)
            {
   
                _logger.LogError($"Something went wrong: {exception}");
                await HandleExceptionAsync(httpContext, exception);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var message = exception switch
            {
                AccessViolationException => 
                    "Access violation error from the custom middleware", 
                _ => "Internal Server Error from the custom middleware."
            };

            await context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = message
            }.ToString() ?? string.Empty);
        }
    }
}
