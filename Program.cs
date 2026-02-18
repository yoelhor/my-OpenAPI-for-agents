using Microsoft.Extensions.Logging.AzureAppServices;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

// Enable Application Insights telemetry collection.
builder.Services.AddApplicationInsightsTelemetry();

// Add Azure stream log service
builder.Logging.AddAzureWebAppDiagnostics();
builder.Services.Configure<AzureFileLoggerOptions>(options =>
{
    options.FileName = "azure-diagnostics-";
    options.FileSizeLimit = 50 * 1024;
    options.RetainedFileCountLimit = 5;
});

builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();

    // Get the Azure hostname
    var websiteHostname = Environment.GetEnvironmentVariable("WEBSITE_HOSTNAME");
    
    if (!string.IsNullOrEmpty(websiteHostname))
    {
        // Production: Use the Azure URL
        c.AddServer(new OpenApiServer { Url = $"https://{websiteHostname}" });
    }
    else 
    {
        // Local: Allow Swagger to use the local dev URL
        c.AddServer(new OpenApiServer { Url = "http://localhost:5292" });
    }

    // To get the swagger document, go to https://localhost:5292/swagger/v1/swagger.json
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My OpenAPI for agents demo API",
        Version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "Unknown",
        Description = "This is a demo API for My OpenAPI for agents.",
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Add request logging middleware
app.UseMiddleware<RequestLoggingMiddleware>();

// Map controller routes
app.MapControllers();
app.UseHttpsRedirection();

// Enable middleware to serve generated Swagger as a JSON endpoint and the Swagger UI.
app.UseSwagger();
app.UseSwaggerUI();

app.Run();


