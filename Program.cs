using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();


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

app.MapControllers();
app.UseHttpsRedirection();

// Enable middleware to serve generated Swagger as a JSON endpoint and the Swagger UI.
app.UseSwagger();
app.UseSwaggerUI();

app.Run();


