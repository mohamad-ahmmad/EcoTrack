using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Report_Processor_Service.Services.App;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddSingleton<IApplication, Application>();

var host = builder.Build();
var app = host.Services.GetRequiredService<Application>();

app.Run();