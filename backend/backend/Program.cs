using backend.CasosDeUso;
using backend.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting(routing => routing.LowercaseUrls = true); //poner para las letras obligatorio

//builder.Services.AddDbContext<CustomerDatabaseContext>(builder =>

builder.Services.AddDbContext<CustomerDatabaseContext>(mysqlBuilder =>
{
    mysqlBuilder.UseMySQL(builder.Configuration.GetConnectionString("ConnectionDB"));//esta en el json de appsetting
    //builder.UseMySQL("Server=localhost;Port=3306;Database=customerdatabase;Uid=root;pwd=");//conexion con la DB pero no es buena practica hacer esto
    //builder.UseMySQL();
});

builder.Services.AddScoped<IUpdateCustomerUseCase, UpdateCustomerUseCase>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("NewPolitics", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("NewPolitics");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
