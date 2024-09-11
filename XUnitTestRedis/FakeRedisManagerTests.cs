using Xunit;
using RedisSolution.Utils;
using StackExchange.Redis;

namespace XUnitTestRedis
{
    public class FakeRedisManagerTests
    {
        private readonly FakeRedisManager _redisManager;

        public FakeRedisManagerTests()
        {
            //Create a new instance of the FakeRedisManager before each test
            _redisManager = new FakeRedisManager();
        }

        [Fact]
        public void WriteDataToRedis_ShouldStoreValueInFakeDataStore()
        {
            // Act: Write data to the fake Redis manager
            _redisManager.WriteDataToRedis("testKey", "testValue");

            // Assert: Ensure that the value can be retrieved from the fake store
            var result = _redisManager.GetDataFromRedis("testKey");
            Assert.Equal("testValue", result);
        }
        [Fact]
        public void GetDataFromRedis_ShouldReturnNullIfKeyDoesNotExist()
        {
            // Act: Try to get a value that hasn't been set
            var result = _redisManager.GetDataFromRedis("nonExistentKey");

            // Assert: The result should be null
            Assert.Null(result);
        }

        [Fact]
        public void Execute_ShouldReturnEmptyRedisResult()
        {
            // Act: Simulate executing a Redis command
            var result = _redisManager.Execute("PING");
            // This allows subtypes of RedisResult like ArrayRedisResult
            Assert.IsAssignableFrom<RedisResult>(result); 
        }
    }
}