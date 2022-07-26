using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using W_03.API.Filters;
using W_03.API.Middlewares;
using W_03.Core.Entities;
using W_03.Core.Repositories;
using W_03.Core.Services;
using W_03.Core.UnitOfWorks;
using W_03.Repository;
using W_03.Repository.Repositories;
using W_03.Repository.UnitOfWorks;
using W_03.Service.Mapping;
using W_03.Service.Services;
using W_03.Service.Validations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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
.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<UserLoginViewValidator>())
.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<PreRegistrationViewValidator>())
.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<PreRegisteredUserRegistrationViewValidator>())
.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<UserInformationUpdateViewValidator>())
.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<SaleAddViewValidator>())
.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ProductAddViewValidator>());

builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddTransient<IMailService, MailService>();


builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
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

app.UseCustomException();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
