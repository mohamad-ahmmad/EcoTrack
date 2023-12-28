using Report_Processor_Service.Models;
using Report_Processor_Service.Services.MessageConsumer;
using Report_Processor_Service.Services.MessageProcessor;

namespace Report_Processor_Service.Services.App
{
    public class Application : IApplication
    {
        private readonly IMessageConsumer<EnviromentalReportMessage> _reportConsumer;
        private readonly IMessageProcessor<EnviromentalReportMessage> _reportProcessor;

        public Application(
            IMessageConsumer<EnviromentalReportMessage> reportConsumer,
            IMessageProcessor<EnviromentalReportMessage> reportProcessor)
        {
            _reportConsumer = reportConsumer ?? 
                throw new ArgumentNullException(nameof(reportConsumer));
            _reportProcessor = reportProcessor ?? 
                throw new ArgumentNullException(nameof(reportProcessor));
        }
        public void Run()
        {
            _reportConsumer.StartConsuming(_reportProcessor);
            Console.ReadLine();
        }
    }
}
