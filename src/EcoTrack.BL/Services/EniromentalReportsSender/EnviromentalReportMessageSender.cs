using AutoMapper;
using EcoTrack.BL.Interfaces;
using EcoTrack.BL.Models;
using EcoTrack.PL.Entities;

namespace EcoTrack.BL.Services.EniromentalReportsSender
{
    public class EnviromentalReportMessageSender : IEnviromentalReportMessageSender
    {
        private readonly IMessageSender<EnviromentalReportMessage> _messageSender;
        private readonly IMapper _mapper;
        private const string _routingKey = "EnviromentalReport";

        public EnviromentalReportMessageSender(
            IMessageSender<EnviromentalReportMessage> messageSender,
            IMapper mapper)
        {
            _messageSender = messageSender ?? 
                throw new ArgumentNullException(nameof(messageSender));
            _mapper = mapper ?? 
                throw new ArgumentNullException(nameof(mapper));
        }
        public void SendReport(EnviromentalReport report)
        {
            var reportMessage = _mapper.Map<EnviromentalReportMessage>(report);
            _messageSender.SendMessage(reportMessage, _routingKey);
        }
    }
}
