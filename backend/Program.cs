using Microsoft.EntityFrameworkCore;
using UDV_Benefits.Domain.Interfaces;
using UDV_Benefits.Infrastructure.Data;
using UDV_Benefits.Services;
using UDV_Benefits.Services.Auth;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//—ервисы
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IWorkerService, WorkerService>();

#if RELEASE
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("UdvBenefitsDbLinux"))
    );
#else
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("UdvBenefitsDb"))
    );
#endif

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

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.Urls.Add("http://0.0.0.0:7178");

//app.UseHttpsRedirection();
app.UseCors(myAllowSpecificOrigins);
//TODO: добавить авторизацию на jwt токенах
app.UseAuthorization();

app.MapControllers();

app.Run();
