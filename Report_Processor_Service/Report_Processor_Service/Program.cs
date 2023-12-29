using EcoTrack.PL;
using EcoTrack.PL.Repositories.Users;
using EcoTrack.PL.Repositories.Users.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using Report_Processor_Service.Models;
using Report_Processor_Service.Services.App;
using Report_Processor_Service.Services.MessageConsumer;
using Report_Processor_Service.Services.MessageProcessor;
using Report_Processor_Service.Services.MessageSerializer;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSingleton<IApplication, Application>();
builder.Services.AddSingleton<IMessageProcessor<EnviromentalReportMessage>, EnviromentalReportProcessor>();
builder.Services.AddScoped<IMessageConsumer<EnviromentalReportMessage>, RabbitMqMessageConsumer<EnviromentalReportMessage>>();
builder.Services.AddSingleton(typeof(IMessageSerializer<>), typeof(JsonMessageSerializer<>));
builder.Services.AddScoped(sp =>
{
    var config = sp.GetRequiredService<IOptionsSnapshot<RabbitMqConfiguration>>().Value;
    return new ConnectionFactory() { HostName = config.IpAddress }.CreateConnection();
});
builder.Services.AddScoped<IUserRepository, SqlUserRepository>();
builder.Services.AddDbContext<EcoTrackDBContext>(options =>
{
    var mysqlConnection = builder.Configuration["ConnectionStrings:MySqlConnectionString"];
    options.UseMySql(mysqlConnection, ServerVersion.AutoDetect(mysqlConnection));
});

builder.Services.Configure<RabbitMqConfiguration>(builder.Configuration.GetSection("RabbitMq"));

var host = builder.Build();
var app = host.Services.GetRequiredService<Application>();

app.Run();