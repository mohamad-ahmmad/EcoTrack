using EcoTrack.BL.Services.EnviromentalReportTopics.Interface;
using EcoTrack.BL.Services.EnviromentalReportTopics;
using EcoTrack.BL.Services.EnviromentalThresholds.Interface;
using EcoTrack.BL.Services.EnviromentalThresholds;
using EcoTrack.BL.Services.Users.Interfaces;
using EcoTrack.BL.Services.Users;
using EcoTrack.PL.Repositories.EnviromentalReportsTopics.Interface;
using EcoTrack.PL.Repositories.EnviromentalReportsTopics;
using EcoTrack.PL.Repositories.EnviromentalThresholds.Interface;
using EcoTrack.PL.Repositories.EnviromentalThresholds;
using EcoTrack.PL.Repositories.Users.Interface;
using EcoTrack.PL.Repositories.Users;
using EcoTrack.PL;
using Microsoft.EntityFrameworkCore;
using EcoTrack.BL.Services.EnviromentalReports.Interface;
using EcoTrack.BL.Services.EnviromentalReports;
using EcoTrack.PL.Repositories.EnviromentalReports;
using EcoTrack.BL.Interfaces;
using EcoTrack.BL.Services.MessageSerializer;
using EcoTrack.BL.Services.MessageSender;

namespace EcoTrack.API
{
    public static class ServiceRegistrant
    {
        public static IServiceCollection AddEcoTrack(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, SqlUserRepository>();
            services.AddScoped<IEnviromentalThresholdsRepository, SqlEnviromentalThresholdRepository>();
            services.AddScoped<IEnviromentalReportsTopicsRepository, SqlEnviromentalReportsTopicsRepository>();
            services.AddSingleton<IEnviromentalReportsRepository, EnviromentalReportsRepository>();
            
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IEnviromentalReportTopicsService, EnviromentalReportTopicsService>();
            services.AddScoped<IEnviromentalThresholdsService, EnviromentalThresholdsService>();
            services.AddSingleton<IEnviromentalReportsService, EnviromentalReportsService>();

            services.AddSingleton(typeof(IMessageSerializer<>), typeof(JsonMessageSerializer<>));
            services.AddSingleton(typeof(IMessageSender<>), typeof(RabbitMqMessageSender<>));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }

    }
}
