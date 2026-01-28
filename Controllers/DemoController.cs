// GET: api/todos
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

public class DemoController : ControllerBase
{

    public DemoController()
    {

    }

    [HttpGet("api/info")]
    [SwaggerOperation(
        Summary = "Gets the Online Ticketing demo API information", 
        OperationId = "GetOpenApiInfo",
        Description = "Gets the Online Ticketing demo API information including version and service name.")]
    [ProducesResponseType(typeof(string), 200)]
    public async Task<ActionResult<string>> GetOpenApiInfo()
    {

        var version = System.Reflection.Assembly.GetExecutingAssembly()
        .GetName().Version?.ToString() ?? "Unknown";

        return Ok($"My OpenAPI for agents demo. Version: {version}, Name:{(string.IsNullOrEmpty(Environment.MachineName) ? "Unknown" : Environment.MachineName)}");
    }
}



