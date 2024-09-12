using StackExchange.Redis;

namespace RedisSolution.Utils.Interfaces
{
    /// <summary>
    /// Interface defining core operations for Redis management.
    /// Provides methods for writing, reading, and executing Redis commands.
    /// </summary>
    public interface IRedisManager
    {
        /// <summary>
        /// Writes a key-value pair to the Redis server.
        /// </summary>
        /// <param name="key">The key under which the value will be stored.</param>
        /// <param name="value">The value to be stored.</param>
        void WriteDataToRedis(string key, string value);

        /// <summary>
        /// Retrieves the value stored under the given key from the Redis server.
        /// </summary>
        /// <param name="key">The key of the stored value.</param>
        /// <returns>The value stored under the provided key, or null if the key doesn't exist.</returns>
        string GetDataFromRedis(string key);

        /// <summary>
        /// Executes a Redis command with the provided arguments.
        /// </summary>
        /// <param name="command">The Redis command to execute (e.g., PING, GET, etc.).</param>
        /// <param name="args">The arguments required for the Redis command.</param>
        /// <returns>The result of the command execution as a RedisResult object.</returns>
        RedisResult Execute(string command, params object[] args);
    }
}
