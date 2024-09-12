using RedisSolution.Utils.Interfaces;
using StackExchange.Redis;

namespace RedisSolution.Utils
{
    /// <summary>
    /// A fake implementation of IRedisManager for testing purposes.
    /// Simulates Redis operations using an in-memory data store.
    /// </summary>
    public class FakeRedisManager : IRedisManager
    {
        // In-memory data store to simulate Redis key-value pairs.
        private readonly Dictionary<string, string> _fakeDataStore = new Dictionary<string, string>();

        /// <summary>
        /// Simulates writing a key-value pair to Redis by storing it in an in-memory dictionary.
        /// </summary>
        /// <param name="key">The key under which the value will be stored.</param>
        /// <param name="value">The value to be stored.</param>
        public void WriteDataToRedis(string key, string value)
        {
            _fakeDataStore[key] = value;  // Simulate writing to Redis
        }

        /// <summary>
        /// Simulates retrieving a value from Redis by checking the in-memory dictionary.
        /// </summary>
        /// <param name="key">The key of the stored value.</param>
        /// <returns>The value associated with the provided key, or null if the key doesn't exist.</returns>
        public string GetDataFromRedis(string key)
        {
            return _fakeDataStore.ContainsKey(key) ? _fakeDataStore[key] : null;  // Simulate reading from Redis
        }

        /// <summary>
        /// Simulates executing a Redis command and returning a RedisResult.
        /// This uses a hardcoded "OK" result for all commands.
        /// </summary>
        /// <param name="command">The Redis command to execute.</param>
        /// <param name="args">The arguments for the command (if any).</param>
        /// <returns>A RedisResult object representing the result of the command execution.</returns>
        public RedisResult Execute(string command, params object[] args)
        {
            // Simulate a Redis command execution using a RedisValue array with a hardcoded "OK" result.
            RedisValue[] values = new RedisValue[] { "OK" };
            return RedisResult.Create(values);  // Return a RedisResult using the RedisValue array
        }
    }
}
