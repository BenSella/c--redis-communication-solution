using StackExchange.Redis;
using Microsoft.Extensions.Configuration;
using RedisSolution.Utils.Interfaces;

namespace RedisSolution.Utils
{
    public class RedisManager : IRedisManager
    {
        private readonly IDatabase _redisDatabase;

        public RedisManager(IConfiguration configuration, IConnectionMultiplexer connectionMultiplexer)
        {
            _redisDatabase = connectionMultiplexer.GetDatabase();
        }

        public void WriteDataToRedis(string key, string value)
        {
            _redisDatabase.StringSet(key, value);
        }

        public string GetDataFromRedis(string key)
        {
            return _redisDatabase.StringGet(key);
        }

        public RedisResult Execute(string command, params object[] args)
        {
            return _redisDatabase.Execute(command, args);
        }
    }

}
