using Report_Processor_Service.Models;

namespace Report_Processor_Service.Services.MessageProcessor
{
    public class EnviromentalReportProcessor : IMessageProcessor<EnviromentalReportMessage>
    {
        public EnviromentalReportProcessor()
        {
            
        }
        public void Process(EnviromentalReportMessage message)
        {
            throw new NotImplementedException();
        }
    }
}
