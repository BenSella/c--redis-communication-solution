#This project provides a Redis manager solution designed to help 
developers interact with a Redis server by offering utilities to write, retrieve, 
execute commands on Redis. It includes both a real Redis integration using the StackExchange.
Redis library and a mock (fake) Redis implementation for testing purposes using xUnit.

Architecture Overview:
#RedisSolution 
├── RedisSolution 
│ ├── Utils 
│ │ ├── Interfaces 
│ │ │ └── IRedisManager.cs
│ │ ├── FakeRedisManager.cs
│ │ └── RedisManager.cs
│ └── Program.cs └── XunitTestRedis └── FakeRedisManagerTest.cs
