using Api.ServiceConcretes;
using Api.ServiceContracts;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IPersonService, PersonService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSoapEndpoint<IPersonService>("/Service.asmx", new SoapEncoderOptions());

app.UseHttpsRedirection();

app.Run();