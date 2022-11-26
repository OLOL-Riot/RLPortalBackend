using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RLPortalBackend.Helpers;
using RLPortalBackend.Models;
using RLPortalBackend.Repositories;
using RLPortalBackend.Repositories.Impl;
using RLPortalBackend.Services;
using RLPortalBackend.Services.Impl;
using MassTransit;
using RLPortalBackend.Mappers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Swashbuckle.AspNetCore.Filters;
using RLPortalBackend.Helpers.Impl;
using RLPortalBackend;
using RLPortalBackend.Entities;

var builder = WebApplication.CreateBuilder(args);
//Postgres
var connectionString = builder.Configuration.GetConnectionString("AplicationDBContextConnection") ?? throw new InvalidOperationException("Connection string 'AplicationDBContextConnection' not found.");

builder.Services.AddDbContext<AplicationDBContext>(options =>
    options.UseNpgsql(connectionString));
//Как поднимается сервис паблишера и ребита поменять значнеие на true для подтвреждения почты
builder.Services.AddDefaultIdentity<UserEntity>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AplicationDBContext>();

// Connection to the MongoDB
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("RLPortalMongoDB"));

builder.Services.AddControllersWithViews();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "RLPortalBackend API", Version = "v0.1" });
    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standart Authorization header using the Bearer scheme (\"bearer {token}\")", 
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.OperationFilter<SecurityRequirementsOperationFilter>();
    var filepath = Path.Combine(System.AppContext.BaseDirectory, "RLPortalBackend.xml");
    c.IncludeXmlComments(filepath);
});

//Injections
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<ITestRepository, TestRepository>();
builder.Services.AddScoped<ITestService, TestService>();
builder.Services.AddScoped<IVerifiedTestRepository, VerifiedTestRepository>();
builder.Services.AddScoped<IVerifiedTestService, VerifiedTestService>();
builder.Services.AddScoped<ITheoryRepository, TheoryRepository>();
builder.Services.AddScoped<ITheoryService, TheoryService>();
builder.Services.AddScoped<ICourseSectionRepository, CourseSectionRepository>();
builder.Services.AddScoped<ICourseSectionService, CourseSectionService>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ICourseService, CourseService>();

builder.Services.AddScoped<IUserAuthenticationRepository, UserAuthenticationRepository>();
builder.Services.AddScoped<IEmailSenderService, EmailSenderService>();
builder.Services.AddScoped<ITokenHelper, TokenHelper>();
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = true;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Secret").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddCors();
builder.Services.AddAutoMapper(typeof(AppMappingProfile));

initRabbitMQ();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); ;

app.UseAuthorization();

var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UserEntity>>();
    SeedData.Seed(userManager, roleManager);
}

app.UseMiddleware();

app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("v1/swagger.json", "My API V1");
});

//app.UseMiddleware<JwtMiddleware>();

app.Run();


void initRabbitMQ()
{
    builder.Services.AddMassTransit(x =>
    {

        x.SetKebabCaseEndpointNameFormatter();

        x.UsingRabbitMq((context, cfg) =>
        {
            cfg.Host("localhost", "/", h =>
            {
                h.Username("guest");
                h.Password("guest");
            });

            cfg.ConfigureEndpoints(context);
        });
    });
}