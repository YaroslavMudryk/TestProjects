using Redis.OM.Modeling;
using TestProjects.Redis.Strategy;

namespace TestProjects.Redis.Models
{
    [Document(StorageType = StorageType.Json, IdGenerationStrategyName = nameof(StaticIncrementStrategy))]
    public class Customer
    {
        [RedisIdField]
        public string Id { get; set; }
        [Indexed]
        public int CustomerId { get; set; }
        [Indexed]
        public string FirstName { get; set; }
        [Indexed]
        public string LastName { get; set; }
        public string Email { get; set; }
        [Indexed(Sortable = true)]
        public int Age { get; set; }
        [Indexed]
        public string[] NickNames { get; set; }
    }
}
