using Microsoft.EntityFrameworkCore;
using MoneyPro2.Api.Services;
using MoneyPro2.Domain.Data;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
LoadConfiguration(builder);
ConfigureMvc(builder);
ConfigureServices(builder);


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

void LoadConfiguration(WebApplicationBuilder builder)
{
    MoneyPro2.Api.Configuration.JwtKey = builder.Configuration.GetValue<string>("JwtKey");
    MoneyPro2.Api.Configuration.ApiKeyName = builder.Configuration.GetValue<string>("ApiKeyName");
    MoneyPro2.Api.Configuration.ApiKey = builder.Configuration.GetValue<string>("ApiKey");

    var smtp = new MoneyPro2.Api.Configuration.SmtpConfiguration();
    builder.Configuration.GetSection("Smtp").Bind(smtp);
    MoneyPro2.Api.Configuration.Smtp = smtp;
}

void ConfigureMvc(WebApplicationBuilder builder)
{
    builder.Services.AddControllers().ConfigureApiBehaviorOptions(options => { options.SuppressModelStateInvalidFilter = true; }).AddJsonOptions(x =>
    {
        x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
    });
}

void ConfigureServices(WebApplicationBuilder builder)
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<MoneyPro2DataContext>(options => options.UseSqlServer(connectionString));

    builder.Services.AddTransient<TokenServices>();
}
