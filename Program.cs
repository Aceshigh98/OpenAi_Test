using Cgpt.Services;
using Cgpt.Configurations;


var builder = WebApplication.CreateBuilder(args);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// Adding Swagger
builder.Services.AddSwaggerGen();
// Adding Controllers
builder.Services.AddControllers();
//Dependency Injection for OpenAiService
builder.Services.Configure<OpenAiConfig>(builder.Configuration.GetSection("OpenAi"));
// Adding OpenAI service
builder.Services.AddScoped<OpenAiService>();
// Build the app
var app = builder.Build();
// Enable middleware to serve the generated Swagger as a JSON endpoint.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  // Enable Swagger middleware to generate Swagger JSON file
    app.UseSwaggerUI();  // Enable Swagger UI to visualize the Swagger documentation in a browser
}

app.MapControllers();
app.Run();