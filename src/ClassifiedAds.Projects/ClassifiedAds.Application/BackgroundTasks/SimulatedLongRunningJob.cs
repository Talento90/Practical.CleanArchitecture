using ClassifiedAds.Domain.Notification;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace ClassifiedAds.Application.BackgroundTasks
{
    public class SimulatedLongRunningJob
    {
        private readonly IConfiguration _configuration;
        private readonly IWebNotification _notification;

        public SimulatedLongRunningJob(IConfiguration configuration, IWebNotification notification)
        {
            _configuration = configuration;
            _notification = notification;
        }

        public async Task Run()
        {
            var endpoint = $"{_configuration["NotificationServer:Endpoint"]}/SimulatedLongRunningTaskHub";
            await _notification.SendAsync(endpoint, "SendTaskStatus", new { Step = "Step 1", Message = "Begining xxx" });

            Thread.Sleep(2000);

            await _notification.SendAsync(endpoint, "SendTaskStatus", new { Step = "Step 1", Message = "Finished xxx" });
        }
    }
}
