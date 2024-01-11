using APIDeps.Interfaces;
using APIDeps.Mappings;
using APIDeps.Rest;
using APIDeps.Services;
using Microsoft.EntityFrameworkCore;
using postgreAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*CONFIG*/
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DatabaseConnection"));
});

builder.Services.AddSingleton<IPepCpfService, PepCpfService>();
builder.Services.AddSingleton<ICepimCnpjService, CepimCnpjService>();
builder.Services.AddSingleton<IPortalTransparenciaAPI, PortalTransparenciaRest>();

builder.Services.AddAutoMapper(typeof(PepCpfMapping));
builder.Services.AddAutoMapper(typeof(CepimCnpjMapping));

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
