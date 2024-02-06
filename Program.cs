using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using authentication_api.Data;
using authentication_api.Services.BoardsService;
using authentication_api.Services.TokenService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DATABASE
// If you want to use database in memory, uncomment this part (lines 17~19):
builder.Services.AddDbContext<DataContext>(opt => 
    opt.UseInMemoryDatabase("AuthenticationDB")
);

// If you want to use the PostgreSQL database, uncomment this part (lines 22~24):
// AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
// var conn = builder.Configuration.GetConnectionString("DefaultConnection");
// builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(conn));

// Configure JWT authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = builder.Configuration["JwtSecurityToken:Audience"],
            ValidIssuer = builder.Configuration["JwtSecurityToken:Issuer"],
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSecurityToken:Key"] ?? string.Empty))
        };
    });

var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();

if(allowedOrigins != null)
{
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("corsPolicy", policy =>
        {
            policy.WithOrigins(allowedOrigins)
                    .AllowAnyHeader()
                    .AllowAnyMethod();
        });
    });
}

// Services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("corsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
