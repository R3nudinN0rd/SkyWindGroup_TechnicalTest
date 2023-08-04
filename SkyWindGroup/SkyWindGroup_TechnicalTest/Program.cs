using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using SkyWindGroup_TechnicalTest.Context;
using SkyWindGroup_TechnicalTest.Entities.Profiles;
using SkyWindGroup_TechnicalTest.Repository.TicketRepository;
using SkyWindGroup_TechnicalTest.Repository.UserRepository;
using SkyWindGroup_TechnicalTest.Services.CurrencyRepository;
using SkyWindGroup_TechnicalTest.Services.DrawHistoryRepository;
using SkyWindGroup_TechnicalTest.Services.LotteryTypeRepository;
using SkyWindGroup_TechnicalTest.Services.PrizeRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddResponseCaching();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Mapper Profiles
builder.Services.AddAutoMapper(typeof(UserProfile).Assembly);
builder.Services.AddAutoMapper(typeof(TicketProfile).Assembly);
builder.Services.AddAutoMapper(typeof(PrizeProfile).Assembly);
builder.Services.AddAutoMapper(typeof(LotteryTypeProfile).Assembly);
builder.Services.AddAutoMapper(typeof(CurrencyProfile).Assembly);
builder.Services.AddAutoMapper(typeof(DrawHistoryProfile).Assembly);
#endregion

builder.Services.AddDbContext<SkyWindTTContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

#region Entity Services
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<IPrizeRepository, PrizeRepository>();
builder.Services.AddScoped<ILotteryTypeRepository, LotteryTypeRepository>();
builder.Services.AddScoped<IDrawHistoryRepository, DrawHistoryRepository>();
builder.Services.AddScoped<ICurrencyRepository, CurrencyRepository>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
app.UseResponseCaching();

app.Run();
