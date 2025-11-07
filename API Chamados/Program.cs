using Microsoft.EntityFrameworkCore;
using API_Chamados.Data;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using API_Chamados.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString)
    );

var jwtSettings = builder.Configuration.GetSection("Jwt");
var secretKey = Encoding.ASCII.GetBytes(jwtSettings["Secret"]);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false; // Em produção, considere true
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true, // Validar a chave secreta
        IssuerSigningKey = new SymmetricSecurityKey(secretKey), // Pega a chave secreta
        ValidateIssuer = true, // Validar quem emitiu
        ValidIssuer = jwtSettings["Issuer"], // Pega o Issuer do appsettings
        ValidateAudience = true, // Validar quem pode receber
        ValidAudience = jwtSettings["Audience"], // Pega o Audience do appsettings
        ClockSkew = TimeSpan.Zero // Remove tempo de tolerância na expiração
    };
});

// DI de serviços
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IServicoSenha, ServicoSenhaBcrypt>();

// MVC + API
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // Configura segurança do Swagger para JWT
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "API Chamados", Version = "v1" });
    var securityScheme = new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Informe o token JWT como: Bearer {token}"
    };
    options.AddSecurityDefinition("Bearer", securityScheme);
    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            securityScheme,
            new string[] {}
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
app.UseStaticFiles(); // servir css/js/img

app.UseAuthentication();
app.UseAuthorization();

// Rotas API (attribute routing)
app.MapControllers();

// Rota MVC convencional (para controladores sem [Route])
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

await API_Chamados.Data.DbSeeder.SeedInicialAsync(app);

app.Run();
