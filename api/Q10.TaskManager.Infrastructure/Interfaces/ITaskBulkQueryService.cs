using Q10.TaskManager.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q10.TaskManager.Infrastructure.Interfaces
{
    public interface ITaskBulkQueryService
    {
        Task<List<TaskBulkResponse>> GetBulkTaskResultsAsync(string commandId);
    }
}
