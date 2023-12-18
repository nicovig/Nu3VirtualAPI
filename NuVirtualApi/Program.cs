using NuVirtualApi.Database;
using NuVirtualApi.Domain.Business;
using NuVirtualApi.Domain.Interfaces.Business;
using NuVirtualApi.Domain.Models.Config;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using NuVirtualApi.Domain.Managers;
using NuVirtualApi.Domain.Interfaces.Managers;
using NuVirtualApi.Domain.Interfaces.Manager;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "NuVirtualApi", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        Description = "Ajouter le token ainsi : \"Bearer xxxx\" où xxxx est votre token d'authentification",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] {}
        }
    });
});

//Database dependency injections
builder.Services.AddDbContext<DatabaseContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection_local")));
    //options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection_production")));

//Others dependency injections
builder.Services.AddScoped<IAuthenticationBusiness, AuthenticationBusiness>();

builder.Services.AddScoped<IFavoriteMealManager, FavoriteMealManager>();
builder.Services.AddScoped<IFavoriteMealBusiness, FavoriteMealBusiness>();

builder.Services.AddScoped<IMealManager, MealManager>();
builder.Services.AddScoped<IMealBusiness, MealBusiness>();

builder.Services.AddScoped<IMonitoringManager, MonitoringManager>();
builder.Services.AddScoped<IMonitoringBusiness, MonitoringBusiness>();

builder.Services.AddScoped<INutritionGoalManager, NutritionGoalManager>();
builder.Services.AddScoped<INutritionGoalBusiness, NutritionGoalBusiness>();

builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<IUserBusiness, UserBusiness>();

builder.Services.AddScoped<IWorkoutManager, WorkoutManager>();
builder.Services.AddScoped<IWorkoutBusiness, WorkoutBusiness>();

//configuration de l'authentification et du format de token
//https://www.attineos.com/blog/actu/creer-une-api-en-net-6
var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

})

.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Issuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
        ClockSkew = TimeSpan.Zero
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
