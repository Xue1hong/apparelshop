<<<<<<< HEAD
using apparelshop.Contracts;
using apparelshop.Repositories;
using apparelshop.Utilities;
using Microsoft.Data.SqlClient;
using System.Data;

=======
using apparelshop.Utilities;
>>>>>>> ec7c70ed4eed821ffac1aa9b43f25d5e76e4f3e5

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// �`�J�@�ӳ�Ҫ�DbContext ���O�Ө�U��Ʈw�s�u
builder.Services.AddSingleton<DbContext>();
<<<<<<< HEAD

// �`�JIDbConnection
builder.Services.AddScoped<IDbConnection>(sp => sp.GetRequiredService<DbContext>().CreateConnection());

// �NMemberRepository ��������Ҫ`�J��IProducts �e����
builder.Services.AddScoped<IProducts, ProductsRepository>();
// �NCalendarRepository ��������Ҫ`�J��ICustomers �e����
builder.Services.AddScoped<ICustomers, CustomersRepository>();

// �NCrossRepository ��������Ҫ`�J��ICross �e����
builder.Services.AddScoped<ICross, CrossRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAny",
        policy =>
        {
            policy.WithOrigins("https://localhost:7046", "http://localhost:5068")
                                .AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});


=======
>>>>>>> ec7c70ed4eed821ffac1aa9b43f25d5e76e4f3e5
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

<<<<<<< HEAD
app.UseCors("AllowAny");

=======
>>>>>>> ec7c70ed4eed821ffac1aa9b43f25d5e76e4f3e5
app.Run();
