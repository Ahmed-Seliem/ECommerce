using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Core.Interfaces;
using API.Helpers;

var builder = WebApplication.CreateBuilder(args);

    // var host = builder.Build();
    // using (var scope= host.Services.CreateScope())
    // {
    //     var services=  scope.ServiceProvider;
    //    var loggerFactory= services.GetRequiredService<ILoggerFactory>();
    //    try
    //    {
    //        var context= services.GetRequiredService<StoreContext>();
    //        await context.Database.MigrateAsync();
    //        await StoreContextSeed.SeedAsync(context, loggerFactory);
    //    }
    //    catch (Exception ex) 
    //    {
           
    //        var logger= loggerFactory.CreateLogger<Program>();
    //        logger.LogError(ex, "An error occurs");
    //    }
    //    host.Run();

    // }



// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<StoreContext>(options => 
       options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
       builder.Services.AddScoped<IProductRepository, ProductRepository>();
       builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
       builder.Services.AddAutoMapper(typeof(MappingProfiles));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseStaticFiles();

app.MapControllers();

app.Run();
