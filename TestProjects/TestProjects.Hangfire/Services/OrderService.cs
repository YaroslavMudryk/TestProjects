using Hangfire;

namespace TestProjects.Hangfire.Services
{
    public class OrderService
    {
        private readonly IBackgroundJobClient _backgroundJobClient;
        public OrderService(IBackgroundJobClient backgroundJobClient)
        {
            _backgroundJobClient = backgroundJobClient;
        }

        public void ProcessOrder()
        {
            _backgroundJobClient.Schedule(() => UpdateOrderStatus(), TimeSpan.FromHours(24)); // method will be executed in 24 hours
        }

        public void UpdateOrderStatus()
        {
            Console.WriteLine($"Статус оновлений");
        }
    }
}
