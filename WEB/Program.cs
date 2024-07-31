using Infrastructure;
using WEB;
using Application.DependencyResolver;
using WEB.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

builder.Services.AddHttpContextAccessor();

// Add services to the container.
builder.Services.AddMemoryCache();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();

builder.Services.AddWebServices();
builder.Services.AddPermission();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.AddApplicationServices
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<CustomExceptionHandlerMiddleware>();
app.UseRouting();

app.UseCors(x => x
               .AllowAnyMethod()
               .AllowAnyHeader()
               .SetIsOriginAllowed(origin => true)
               .AllowCredentials());
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
