namespace EcoTrack.BL.Services.EniromentalReportsSender
{
    public interface IEnviromentalReportMessageSender
    {
        void SendReport(EnviromentalReportMessage message);
    }
}
