using StackExchange.Redis;

namespace RedisSolution.Utils.Interfaces
{
    public interface IRedisManager
    {
        void WriteDataToRedis(string key, string value);
        string GetDataFromRedis(string key);
        RedisResult Execute(string command, params object[] args);
    }
}