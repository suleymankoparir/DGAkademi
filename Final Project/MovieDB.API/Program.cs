using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MovieDB.API.Filters;
using MovieDB.API.Modules;
using MovieDB.Repository;
using MovieDB.Service.Mapping;
using MovieDB.Service.Validations;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#pragma warning disable CS0618 // Type or member is obsolete
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ValidateFilterAttribute());
})
.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<MovieAddDtoValidator>())
.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<MovieUpdateDtoValidator>())
.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<MovieCategoryDtoValidator>())
.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<MoviePerformerDtoValidator>())
.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<MovieProducerDtoValidator>())
.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<MovieDirectorDtoValidator>())
.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<MovieAwardDtoValidator>())
.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<MovieAwardDeleteDtoValidator>())
.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<NameDtoValidator>())
.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<UpdateNameDtoValidator>())
.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<AwardAddDtoValidator>())
.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<AwardUpdateDtoValidator>())
.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<PerformerUpdateDtoValidator>())
.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<PerformerAddDtoValidator>())
.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<DirectorAddDtoValidator>())
.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<DirectorUpdateDtoValidator>())
.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<UserAddDtoValidator>())
.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<UserUpdateDtoValidator>())
.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<UserLoginDtoValidator>())
.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ReviewAddDtoValidator>())
.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ReviewUpdateDtoValidator>());
#pragma warning restore CS0618 // Type or member is obsolete

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
#region JWT
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
#endregion
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
#region Swagger
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
#endregion

builder.Services.AddAutoMapper(typeof(MapProfile));


builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseNpgsql(builder.Configuration.GetConnectionString("PostgreConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));

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
