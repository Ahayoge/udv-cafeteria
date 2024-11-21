using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using UDV_Benefits.Domain.Interfaces.AuthService;
using UDV_Benefits.Domain.Interfaces.BenefitRequestService;
using UDV_Benefits.Domain.Interfaces.BenefitService;
using UDV_Benefits.Domain.Interfaces.CategoryService;
using UDV_Benefits.Domain.Interfaces.EmployeeBenefitService;
using UDV_Benefits.Domain.Interfaces.EmployeeService;
using UDV_Benefits.Domain.Interfaces.RegisterService;
using UDV_Benefits.Domain.Interfaces.UserService;
using UDV_Benefits.Extensions;
using UDV_Benefits.Infrastructure;
using UDV_Benefits.Infrastructure.Data;
using UDV_Benefits.Services.AuthService;
using UDV_Benefits.Services.BenefitRequestService;
using UDV_Benefits.Services.BenefitService;
using UDV_Benefits.Services.CategoryService;
using UDV_Benefits.Services.EmployeeBenefitService;
using UDV_Benefits.Services.EmployeeService;
using UDV_Benefits.Services.RegisterService;
using UDV_Benefits.Services.UserService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options
        .JsonSerializerOptions
        .DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Сервисы
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IRegisterService, RegisterService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IBenefitService, BenefitService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IBenefitRequestService, BenefitRequestService>();
builder.Services.AddScoped<IEmployeeBenefitService, EmployeeBenefitService>();

#if RELEASE
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("UdvBenefitsDbLinux"))
    );
#else
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("UdvBenefitsDb"))
    );
#endif

builder.Services.AddHostedService<StatusUpdateService>();

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        policy =>
        {
            policy
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

builder.Services.ConfigureAuthentication();
builder.Services.ConfigureAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseCors(myAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
