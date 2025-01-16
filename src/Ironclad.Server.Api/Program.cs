
using Ironclad.Server.Api.Hubs;
using Ironclad.Server.Api.Services;
using Ironclad.Server.Core.Game;
using Ironclad.Server.Core.Models;

namespace Ironclad.Server.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();
        
        builder.Services.AddSignalR();

        builder.Services.AddHostedService<GameLoopService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapHub<GameHub>("/game");

        app.Run();
    }
}
