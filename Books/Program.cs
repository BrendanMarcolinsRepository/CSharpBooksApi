using Books.Data;
using Books.Reposistories;
using Microsoft.EntityFrameworkCore;
using Books.Mappings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Books.Service;
using Microsoft.Extensions.FileProviders;
using Serilog;
using Books.Middlewares;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

//logger injection
var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("Logs/BookLogs.txt", rollingInterval : RollingInterval.Day)
    .MinimumLevel.Information()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddCors(options =>  
    options.AddPolicy
    (
        name: "MyAllowSpecificOrigins", 
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
            .WithMethods("PUT", "DELETE", "GET", "DELETE")
            .WithHeaders
            (
                HeaderNames.Accept,
                HeaderNames.ContentType,
                HeaderNames.Authorization
            )
            .AllowCredentials()
            .SetIsOriginAllowed(origin =>
            {
                if (string.IsNullOrWhiteSpace(origin)) return false;

                if (origin.ToLower().StartsWith("http://localhost")) return true;

                return false;

            });
        }
    )
);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddHttpContextAccessor();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo { Title = "Books Api", Version = "v1" });
        options.AddSecurityDefinition(
            JwtBearerDefaults.AuthenticationScheme,
            new OpenApiSecurityScheme
            {
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = JwtBearerDefaults.AuthenticationScheme
            }
        );

        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = JwtBearerDefaults.AuthenticationScheme
                    },

                    Scheme = "Oauth2",
                    Name = JwtBearerDefaults.AuthenticationScheme,
                    In = ParameterLocation.Header
                },
                
                new List<String>()
            }

           
        });
    }
);


builder.Services.AddDbContext<BooksDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Ef_Postgres_Db")));

builder.Services.AddDbContext<BookAuthDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Ef_Postgres_Db_Auth")));



//Services
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IDifficultiesService, DifficultiesService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();

///Repositories
builder.Services.AddScoped<IAuthorRepositorycs, PostGresAuthorRepository>();
builder.Services.AddScoped<IBookRepository, PostGresBookRepository>();
builder.Services.AddScoped<IDifficultiesRepository, PostGresDifficultiesRespository>();
builder.Services.AddScoped<ITokenRepository, TokenJwtRepository>();
builder.Services.AddScoped<IImageRepository, LocalImageRepository>();


builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddIdentityCore<IdentityUser>()
        .AddRoles<IdentityRole>()
        .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("Books")
        .AddEntityFrameworkStores<BookAuthDbContext>()
        .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
    {
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = true;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredLength = 8;
        options.Password.RequiredUniqueChars = 1;
    }
); 

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(option =>
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                });

var app = builder.Build();

// ---- Middleware ----
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors("MyAllowSpecificOrigins");

app.UseStaticFiles
(   new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Images")),
        RequestPath = "/Images"
    }
    
);

app.MapControllers();

app.Run();
