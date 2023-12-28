using EcoTrack.PL.Entities;

namespace EcoTrack.BL.Services.EniromentalReportsSender
{
    public interface IEnviromentalReportMessageSender
    {
        void SendReport(EnviromentalReport report);
    }
}
