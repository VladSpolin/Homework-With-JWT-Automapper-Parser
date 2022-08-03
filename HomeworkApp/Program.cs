using Microsoft.EntityFrameworkCore;
using HomeworkApp.Model;
using AutoMapper;
using HomeworkApp.Mapper;
using HomeworkApp.Parser;
using HomeworkApp.BusinessLogic.Implementations;
using HomeworkApp.BusinessLogic.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IClothesService, ClothesService>();
//builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<Parser>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
