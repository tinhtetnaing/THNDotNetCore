using Microsoft.EntityFrameworkCore;
using THNDotNetCore.MiniKpay.Db;
using THNDotNetCore.MiniKpay.Features.Deposit;
using THNDotNetCore.MiniKpay.Features.Transfer;
using THNDotNetCore.MiniKpay.Features.Withdraw;
using THNDotNetCore.MiniKpay.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
}, ServiceLifetime.Transient);

builder.Services.AddSwaggerGen(options =>
{
    options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First()); 
});


builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<TransferService>();
builder.Services.AddScoped<BL_Deposit>();
builder.Services.AddScoped<DA_Deposit>();
builder.Services.AddScoped<BL_Withdraw>();
builder.Services.AddScoped<DA_Withdraw>();
builder.Services.AddScoped<BL_Transfer>();
builder.Services.AddScoped<DA_Transfer>();
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
