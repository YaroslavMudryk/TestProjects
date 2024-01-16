using Hangfire;

namespace TestProjects.Hangfire.Services
{
    public class OrderService
    {
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public OrderService(IBackgroundJobClient backgroundJobClient, IServiceScopeFactory serviceScopeFactory)
        {
            _backgroundJobClient = backgroundJobClient;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public void ProcessOrder()
        {
            _backgroundJobClient.Schedule(() => UpdateOrderStatus(), TimeSpan.FromHours(24)); // method will be executed in 24 hours
        }

        public void UpdateOrderStatus()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            //var dbContext = scope.ServiceProvider.GetService<DbContext>();
            Console.WriteLine($"Статус оновлений");
        }
    }
}
