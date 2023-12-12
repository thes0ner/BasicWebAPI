using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebAPI.DataAccess;
using WebAPI.DataAccess.Abstract;
using WebAPI.DataAccess.Concrete;
using WebAPI.DataAccess.Concrete.context;
using WebAPI.Services.Abstract;
using WebAPI.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<WebApiDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));
builder.Services.AddScoped<ICompanyDal, EfCompanyDal>();
builder.Services.AddScoped<ICompanyService, CompanyManager>();

builder.Services.AddScoped<IContactDal, EfContactDal>();
builder.Services.AddScoped<IContactService, ContactManager>();

builder.Services.AddScoped<ICountryDal, EfCountryDal>();
builder.Services.AddScoped<ICountryService, CountryManager>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });

builder.Services.AddControllers();
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
