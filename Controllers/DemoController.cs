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
        Summary = "Gets web My OpenAPI for agents demo information", 
        OperationId = "GetOpenApiInfo")]
    [ProducesResponseType(typeof(string), 200)]
    public async Task<ActionResult<string>> GetOpenApiInfo()
    {

        var version = System.Reflection.Assembly.GetExecutingAssembly()
        .GetName().Version?.ToString() ?? "Unknown";

        return Ok($"My OpenAPI for agents demo. Version: {version}, Name:{(string.IsNullOrEmpty(Environment.MachineName) ? "Unknown" : Environment.MachineName)}");
    }
}



