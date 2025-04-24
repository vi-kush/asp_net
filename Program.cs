using Microsoft.OpenApi.Models;
using dotnet.Services;
using dotnet.Interfaces;
using dotnet.Exceptions;
using dotnet.Extensions;
using System.Reflection;
using dotnet.EndPoints;
using dotnet.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.AddApplicationServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ToDo API",
        Description = "An ASP.NET Core Web API for managing ToDo items",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => // UseSwaggerUI is called only in Development.
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseExceptionHandler();

app.MapGet("/booksItem", () =>{

    // Wraps the list of books in an HTTP 200 OK response.
    return TypedResults.Ok(new List<BookModel>
    {
        new()
        {
            Title = "Dependency Injection in .NET",
            Author = "Mark Seemann"
        },
        new()
        {
            Title = "C# in Depth",
            Author = "Jon Skeet"
        },
        new()
        {
            Title = "Programming Entity Framework",
            Author = "Julia Lerman"
        },
        new()
        {
            Title = "Programming WCF Services",
            Author = "Juval Lowy and Michael Montgomery"
        }
    });
}).WithName("Get Book")
  .WithOpenApi();

app.MapGroup("/api/v1/")
   .WithTags("Book endpoints")
   .MapBookEndPoint();

app.Run();
