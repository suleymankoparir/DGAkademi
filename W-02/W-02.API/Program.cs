using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using W_02.API.Filters;
using W_02.API.Middlewares;
using W_02.Core.Repositories;
using W_02.Core.Services;
using W_02.Core.UnitOfWorks;
using W_02.Repository;
using W_02.Repository.Repositories;
using W_02.Repository.UnitOfWorks;
using W_02.Service.Mapping;
using W_02.Service.Services;
using W_02.Service.Validations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });
#pragma warning disable CS0618 // Type or member is obsolete
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ValidateFilterAttribute());
})
#pragma warning restore CS0618 // Type or member is obsolete
.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ProductAddDtoValidator>())
.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ProductUpdateDtoValidator>())
.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<PersonLoginDtoValidator>())
.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<PersonSignUpDtoValidator>())
.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<PersonUpdateDtoValidator>())
.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<DepartmentAddDtoValidator>())
.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<DepartmentUpdateDtoValidator>())
.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<RoleAddDtoValidator>())
.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<RoleUpdateDtoValidator>())
.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<TokenValidator>());

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    OpenApiSecurityScheme securityDefinition = new OpenApiSecurityScheme()
    {
        Name = "Bearer",
        BearerFormat = "JWT",
        Scheme = "bearer",
        Description = "Specify the authorization token.",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
    };
    c.AddSecurityDefinition("jwt_auth", securityDefinition);

    // Make sure swagger UI requires a Bearer token specified
    OpenApiSecurityScheme securityScheme = new OpenApiSecurityScheme()
    {
        Reference = new OpenApiReference()
        {
            Id = "jwt_auth",
            Type = ReferenceType.SecurityScheme
        }
    };
    OpenApiSecurityRequirement securityRequirements = new OpenApiSecurityRequirement()
    {
        {securityScheme, new string[] { }},
    };
    c.AddSecurityRequirement(securityRequirements);
}
);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPersonService, PersonService>();

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});
//AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCustomException();///+

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
