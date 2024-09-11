using RedisSolution.Utils.Interfaces;
using StackExchange.Redis;

namespace RedisSolution.Utils
{
    public class FakeRedisManager : IRedisManager
    {
        private readonly Dictionary<string, string> _fakeDataStore = new Dictionary<string, string>();

        public void WriteDataToRedis(string key, string value)
        {
            _fakeDataStore[key] = value;  // Simulate writing to Redis
        }

        public string GetDataFromRedis(string key)
        {
            return _fakeDataStore.ContainsKey(key) ? _fakeDataStore[key] : null;  // Simulate reading from Redis
        }

        public RedisResult Execute(string command, params object[] args)
        {
            // Simulate a Redis command execution using RedisValue array
            RedisValue[] values = new RedisValue[] { "OK" };
            return RedisResult.Create(values);  // Return a RedisResult using the RedisValue array
        }
    }

}
