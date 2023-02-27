using Microsoft.Extensions.Options;
using MongoDB.Driver;
using REST_letcom_API_V2.Models;
using REST_letcom_API_V2.Services;
using ReSTful_letcom_user_management_API.Models;
using ReSTful_letcom_user_management_API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<UsersStoreDatabaseSettings>(
                builder.Configuration.GetSection(nameof(UsersStoreDatabaseSettings)));

builder.Services.AddSingleton<IUsersStoreDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<UsersStoreDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
        new MongoClient(builder.Configuration.GetValue<string>("UsersStoreDatabaseSettings:ConnectionString")));
builder.Services.Configure<AppointmentStoreDatabaseSettings>(
                builder.Configuration.GetSection(nameof(AppointmentStoreDatabaseSettings)));

builder.Services.AddSingleton<IAppointmentStoreDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<AppointmentStoreDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
        new MongoClient(builder.Configuration.GetValue<string>("AppointmentStoreDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<IAppointmentService, AppointmentService>();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
