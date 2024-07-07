
using JSB.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace JSB;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        
        builder.Services.AddDbContext<StoreContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });



        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        #region DataSeed

        using var scope = app.Services.CreateScope(); // Group of services lifetime scopped
        var services = scope.ServiceProvider; // Services It Self

        var LoggerFactory = services.GetRequiredService<ILoggerFactory>();

        try
        {
            var dbcontext = services.GetRequiredService<StoreContext>(); // Ask CLR for creating object from DBcontext Explicitly  == allow DI For DBcontext (StoreContext)

            await StoreContextSeed.seedAsync(dbcontext); // Data seeding
        }
        catch (Exception ex)
        {
            var Logger = LoggerFactory.CreateLogger<Program>();
            Logger.LogError(ex, "An error occured during DataSeeding");
        }

        #endregion

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
