using Redis.OM;
using TestProjects.Redis.Models;

namespace TestProjects.Redis
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var provider = new RedisConnectionProvider("redis://localhost:6379");
            provider.Connection.CreateIndex(typeof(Customer));

            var customers = provider.RedisCollection<Customer>(); // https://github.com/redis/redis-om-dotnet

            customers.Insert(new Customer
            {
                CustomerId = 777,
                FirstName = "User",
                LastName = "Userenko",
                Age = 23,
                Email = "user.userenko@gmail.com",
                NickNames = new string[] { "User01", "Us08", "Searcher01" }
            });


            var filteredCustomers = await customers.Where(s => s.Age > 20).ToListAsync();
        }
    }
}
