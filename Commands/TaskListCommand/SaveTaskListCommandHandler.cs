using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TMSAPI.Models;
using TMSAPI.Queries;
using TMSAPI.Repositories;

namespace TMSAPI.Commands.TaskCommand
{
    public class SaveTaskListCommandHandler : IRequestHandler<SaveTaskListCommand, TaskList>
    {
        private readonly ITaskListRepository _taskListRepository;
        private readonly ITMSQueries _tMSQueries;
        public SaveTaskListCommandHandler(ITaskListRepository taskListRepository, ITMSQueries tMSQueries)
        {
            _taskListRepository = taskListRepository;
            _tMSQueries = tMSQueries;
        }
        public async Task<Models.TaskList> Handle(SaveTaskListCommand cmd, CancellationToken cancellationToken)
        {
            var taskList = await _taskListRepository.GetTaskListById(cmd.Id);
            if (taskList == null)
            {
                var taskNumber = await _tMSQueries.GenerateItem();
                taskList = AddNewTaskList(cmd, taskNumber);
                _taskListRepository.Add(taskList);
            }
            else
            {
                UpdateTaskList(taskList, cmd);
                _taskListRepository.Update(taskList);
            }

            await _taskListRepository.SaveChangesAsync();
            return taskList;
            //return await _customerRepository.AddAsync(request.Customers);
        }
        private TaskList AddNewTaskList(SaveTaskListCommand cmd, string TaskNumber)
        {
            return new TaskList(cmd.TaskDetail, TaskNumber, cmd.TaskStartDate, cmd.TaskFinishDate, cmd.TaskStatus, cmd.AddressId, cmd.VehicleId,cmd.AccountId);
        }
        private void UpdateTaskList(TaskList taskList, SaveTaskListCommand cmd)
        {
            taskList.Update(cmd.TaskDetail, cmd.TaskNumber, cmd.TaskStartDate, cmd.TaskFinishDate, cmd.TaskStatus, cmd.AddressId, cmd.VehicleId, cmd.AccountId);
        }
    }
}
