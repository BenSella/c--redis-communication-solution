using StackExchange.Redis;
using Microsoft.Extensions.Configuration;
using RedisSolution.Utils.Interfaces;

namespace RedisSolution.Utils
{
    /// <summary>
    /// RedisManager provides an implementation for interacting with a real Redis server using StackExchange.Redis.
    /// Implements the IRedisManager interface to handle key-value storage, retrieval, and command execution.
    /// </summary>
    public class RedisManager : IRedisManager
    {
        private readonly IDatabase _redisDatabase;

        /// <summary>
        /// Initializes a new instance of the RedisManager class, connecting to the Redis server using IConnectionMultiplexer.
        /// </summary>
        /// <param name="configuration">The configuration object, potentially used for Redis configuration (not used directly in this implementation).</param>
        /// <param name="connectionMultiplexer">The connection multiplexer to manage Redis connections.</param>
        public RedisManager(IConfiguration configuration, IConnectionMultiplexer connectionMultiplexer)
        {
            // Use the IConnectionMultiplexer to get the Redis database.
            _redisDatabase = connectionMultiplexer.GetDatabase();
        }

        /// <summary>
        /// Writes a key-value pair to the Redis server.
        /// </summary>
        /// <param name="key">The key under which the value will be stored.</param>
        /// <param name="value">The value to be stored.</param>
        public void WriteDataToRedis(string key, string value)
        {
            // Use StringSet to store the value under the given key in Redis.
            _redisDatabase.StringSet(key, value);
        }

        /// <summary>
        /// Retrieves the value stored under the given key from the Redis server.
        /// </summary>
        /// <param name="key">The key of the stored value.</param>
        /// <returns>The value stored under the provided key, or null if the key does not exist.</returns>
        public string GetDataFromRedis(string key)
        {
            // Use StringGet to retrieve the value associated with the key from Redis.
            return _redisDatabase.StringGet(key);
        }

        /// <summary>
        /// Executes a Redis command on the server with the provided arguments.
        /// </summary>
        /// <param name="command">The Redis command to execute (e.g., PING, GET, etc.).</param>
        /// <param name="args">The arguments to the Redis command.</param>
        /// <returns>A RedisResult object representing the result of the command execution.</returns>
        public RedisResult Execute(string command, params object[] args)
        {
            // Execute a custom Redis command and return the result.
            return _redisDatabase.Execute(command, args);
        }
    }
}
