using AutoMapper;
using EcoTrack.BL.Interfaces;
using EcoTrack.PL.Entities;

namespace EcoTrack.BL.Services.EniromentalReportsSender
{
    public class EnviromentalReportMessageSender : IEnviromentalReportMessageSender
    {
        private readonly IMessageSender<EnviromentalReportMessage> _messageSender;
        private readonly IMapper _mapper;

        public EnviromentalReportMessageSender(
            IMessageSender<EnviromentalReportMessage> messageSender,
            IMapper mapper)
        {
            _messageSender = messageSender ?? throw new ArgumentNullException(nameof(messageSender));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public void SendReport(EnviromentalReport message)
        {
            _messageSender.SendMessage(message, "EnviromentalReport");
            throw new NotImplementedException();
        }
    }
}
