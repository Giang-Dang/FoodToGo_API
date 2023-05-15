using FoodToGo_API;
using FoodToGo_API.Data;
using FoodToGo_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});

builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    //options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    //{
    //    Description =
    //        "Input JWT<spacebar>Bearer",
    //    Name = "Authorization",
    //    In = ParameterLocation.Header,
    //    Scheme = "Bearer"
    //});
    //options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    //{
    //    {
    //        new OpenApiSecurityScheme
    //        {
    //            Reference = new OpenApiReference
    //            {
    //                Type = ReferenceType.SecurityScheme,
    //                Id = "Bearer"
    //            },
    //            Scheme = "oauth2",
    //            Name = "Bearer",
    //            In = ParameterLocation.Header
    //        },
    //        new List<String>()
    //    }
    //});
});

var app = builder.Build();

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
