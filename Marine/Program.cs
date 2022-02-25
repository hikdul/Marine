using Marine.Data;
using Marine.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;




// creo mis servicios
var builder = WebApplication.CreateBuilder(args);
//obtengo mi proveedor de configuraciones

var Config = builder.Services.BuildServiceProvider().GetService<IConfiguration>();
// Add services to the container.

builder.Services.AddControllers();

// Para Exponer mis servicios y dejarlos activos
builder.Services.AddTransient<IHostedService, CalculoDiarioCostosServices>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//instancio los valores para mi base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
              options.UseSqlServer(Config.GetConnectionString("DefaultConnection")));

//para el identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
//Auth scheme
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(O =>
{
    O.SaveToken = true;
    O.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Config["jwt:key"])),
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

//add Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Terminal Pesquero",
        Version = "V-0.0.1",
        Description = "App para gestionar los tiempos de produccion de una empresa productora de mariscos congelados",
        Contact = new OpenApiContact()
        {
            Name = "Hector Contreras",
            Email = "hikdul.dev@gmail.com"
        }

    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
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
                        new string[]{ }
                    }
                });
});

//add automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


//configurando mi cookies para intentar redirigir a otro lado 
builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/intro";
    options.Cookie.Name = "YourAppCookieName";
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(6);
    options.LoginPath = "/intro";
    options.LogoutPath = "/intro";
    options.SlidingExpiration = true;
});


//creo mi app
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
