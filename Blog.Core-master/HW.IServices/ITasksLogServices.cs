
using System;
using System.Threading.Tasks;
using HW.IServices.BASE;
using HW.Model;
using HW.Model.Models;

namespace HW.IServices
{	
	/// <summary>
	/// ITasksLogServices
	/// </summary>	
    public interface ITasksLogServices :IBaseServices<TasksLog>
	{
		public Task<PageModel<TasksLog>> GetTaskLogs(long jobId, int page, int intPageSize,DateTime? runTime,DateTime? endTime);
        public Task<object> GetTaskOverview(long jobId, DateTime? runTime, DateTime? endTime, string type);
    }
}
                    