using FoodToGo_API;
using FoodToGo_API.Data;
using FoodToGo_API.Repository;
using FoodToGo_API.Repository.IRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});

builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddResponseCaching();

//set shared folder path to app root folder/UserData


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IMenuItemRepository, MenuItemRepository>();
builder.Services.AddScoped<IMenuItemTypeRepository, MenuItemTypeRepository>();
builder.Services.AddScoped<IMerchantRepository, MerchantRepository>();
builder.Services.AddScoped<IOnlineCustomerLocationRepository, OnlineCustomerLocationRepository>();
builder.Services.AddScoped<IOnlineShipperStatusRepository, OnlineShipperStatusRepository>();
builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
builder.Services.AddScoped<IPromotionRepository, PromotionRepository>(); 
builder.Services.AddScoped<IShipperRepository, ShipperRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOverrideOpenHoursRepository, OverrideOpenHoursRepository>();
builder.Services.AddScoped<INormalOpenHoursRepository, NormalOpenHoursRepository>();
builder.Services.AddScoped<IMenuItemRatingRepository, MenuItemRatingRepository>();
builder.Services.AddScoped<IUserRatingRepository, UserRatingRepository>();
builder.Services.AddScoped<IBanRepository, BanRepository>();
builder.Services.AddScoped<IMenuItemImageRepository, MenuItemImageRepository>();
builder.Services.AddScoped<IMerchantProfileImageRepository, MerchantProfileImageRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

var env = builder.Environment;
var sharedFolderPath = Path.Combine(env.ContentRootPath, "UserData");

builder.Services.Configure<SharedFolderOptions>(options => options.Path = sharedFolderPath);

var key = builder.Configuration.GetValue<string>("ApiSettings:JWTSecret");
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    }
);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description =
            "Input JWT<spacebar>Bearer",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<String>()
        }
    });
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
