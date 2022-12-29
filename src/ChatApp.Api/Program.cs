using ChatApp.Application;
using ChatApp.Infrastructure;
using ChatApp.Api.Hubs;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
    .AddInfrastructure()
    .AddApplication()
    .AddControllers();
    
    builder.Services
        .AddCors()
        .AddSignalR();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.UseCors(builder => builder
        .WithOrigins("null")
        .AllowAnyHeader()
        .SetIsOriginAllowed((host) => true)
        .AllowAnyMethod()
        .AllowCredentials());
    app.MapHub<ChatHub>("/chatHub");
    app.Run();
    app.Run();
}