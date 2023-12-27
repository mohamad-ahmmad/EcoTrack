﻿using EcoTrack.BL.Services.EnviromentalReports.Interface;
using EcoTrack.PL.Entities;
using EcoTrack.PL.Repositories.EnviromentalReportsTopics.Interface;

namespace EcoTrack.BL.Services.EnviromentalReports
{
    public class EnviromentalReportTopicsService : IEnviromentalReportTopicsService
    {
        private readonly IEnviromentalReportsTopicsRepository _envTopicRepo;

        public EnviromentalReportTopicsService(IEnviromentalReportsTopicsRepository envTopicsRepo)
        {
            _envTopicRepo= envTopicsRepo;
        }

        public async Task<IEnumerable<EnviromentalReportsTopic>> GetAllEnviromentalReportsTopics()
        {
           return await _envTopicRepo.GetAllAsync();
        }
        public async Task AddEnviromentalReportsTopics(EnviromentalReportsTopic topic)
        {
             await _envTopicRepo.AddTopicAsync(topic);
        }
    }
}
