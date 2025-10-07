using Microsoft.Extensions.Caching.Memory;
using Q10.TaskManager.Infrastructure.Interfaces;
using System;

namespace Q10.TaskManager.Infrastructure.Repositories
{
    public class EnvironmentRepository : IConfig
    {
        public string GetValue(string key)
        {
            return Environment.GetEnvironmentVariable(key) ?? string.Empty;
        }
    }
}
