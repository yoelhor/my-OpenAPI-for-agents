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
            Summary = "Gets the Online Ticketing demo API information 111",
            OperationId = "GetOpenApiInfo",
            Description = "Gets the Online Ticketing demo API information including version and service name.")]
    [ProducesResponseType(typeof(ApiInfoResponse), 200)] // Reference the new class here
    public async Task<ActionResult<ApiInfoResponse>> GetOpenApiInfo()
    {
        var version = System.Reflection.Assembly.GetExecutingAssembly()
            .GetName().Version?.ToString() ?? "Unknown";

        var serviceName = string.IsNullOrEmpty(Environment.MachineName)
            ? "Unknown"
            : Environment.MachineName;

        return Ok(new ApiInfoResponse
        {
            Version = version,
            Service = serviceName
        });
    }

    /// <summary>
    /// Schema for the API Information response
    /// </summary>
    public class ApiInfoResponse
    {
        [SwaggerSchema("The current version of the web API", ReadOnly = true)]
        public string Version { get; set; } = string.Empty;

        [SwaggerSchema("The identifier for the specific service")]
        public string Service { get; set; } = string.Empty;
    }
}



