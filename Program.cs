using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RestauranteAPI.Context;
using RestauranteAPI.Repositories.Interfaces;
using RestauranteAPI.Repositories;
//using RestauranteAPI.Endpoints;
//using RestauranteAPI.Respositories;
//using RestauranteAPI.Respositories.Interfaces;
using RestauranteAPI.Settings;
using System.Reflection;
using System.Text;
using RestauranteAPI.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Cadena de conexion
builder.Services.AddDbContext<ApplicationDbContext>(o => {
    o.UseSqlServer(builder.Configuration.GetConnectionString("DbConnetion"));
});

//Registrar servicio de automapper y que se pueda inicializar
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// Manda a llamar los datos de la tabla para los endpoints
// Crea una nueva instancia
//builder.Services.AddScoped<>();
//builder.Services.AddScoped<>();
//builder.Services.AddScoped<>();

//Producto Endpoints- para poder hacer uso de nuestros repositorios
builder.Services.AddScoped<IProducto, ProductoRepository>();

// Creacion del token
builder.Services.Configure<TokenSetting>(builder.Configuration.GetSection("TokenSetting"));
// Autorizacion
builder.Services.AddAuthorization();
// Autenticacion
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    // Parámetros de la validacion del token
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidIssuer = builder.Configuration.GetSection("TokenSetting").GetValue<string>("Issuer"),
        ValidateIssuer = true,
        ValidAudience = builder.Configuration.GetSection("TokenSetting").GetValue<string>("Audience"),
        ValidateAudience = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("TokenSetting").GetValue<string>("Key"))),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
    };
});
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Producto API", Version = "v1" });
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Introducir Token",
        Name = "Autorizacion",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement {
        {
            new  OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer",
                }
            },
            new string[]{}
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

app.UseEndpoints();

app.Run();