using Microsoft.EntityFrameworkCore;
using UdemySwagger.Models;
using UdemySwagger.Controllers;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<SwaggerDbContext>(opt => opt.UseSqlServer(builder.Configuration["ConnectionString"])); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(gen=>
{
    gen.SwaggerDoc("V1",new OpenApiInfo()
    {
        Version = "V1",
        Title="Product API",
        Description="Ürün Ekleme/Silme/Güncelleme işlemlerini gerçekleştiren api",
        Contact=new OpenApiContact()
        {
            Name="Enes Çiçek",
            Email="bmenescicek@hotmail.com"
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    gen.IncludeXmlComments(xmlPath);
});





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options=>
    {
        options.SwaggerEndpoint("/swagger/V1/swagger.json","Product API");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
