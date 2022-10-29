using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Core.Interfaces;
using API.Helpers;
using API.Middleware;
using Microsoft.AspNetCore.Mvc;
using API.Errors;
using API.Extensions;

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

builder.Services.AddAutoMapper(typeof(MappingProfiles));
builder.Services.AddApplicationServices();
builder.Services.AddSwaggerDocumentation();
// builder.Services.AddCors(opt =>
// {
//     opt.AddPolicy("CorsPolicy", policy =>
//     {
//         policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
//     });

// });
builder.Services.AddCors();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseMiddleware<ExceptionMiddleware>();
app.UseStatusCodePagesWithReExecute("/errors/{0}");
app.UseHttpsRedirection();
// app.UseCors("CorsPolicy");
app.UseRouting();
app.UseCors(x=>x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthorization();
app.UseStaticFiles();
app.UseSwaggerDocumentation();

app.MapControllers();

app.Run();
