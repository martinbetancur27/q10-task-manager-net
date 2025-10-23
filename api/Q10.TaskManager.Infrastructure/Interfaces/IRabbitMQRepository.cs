using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q10.TaskManager.Infrastructure.Interfaces
{
    public interface IRabbitMQRepository
    {
        Task PublishAsync<T>(T message, string queueName);
        Task StartConsumingAsync<T>(string queueName, Func<T, Task> handler);
    }
}
