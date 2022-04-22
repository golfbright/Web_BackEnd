using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TMSAPI.Commands.SaveAccountRolesCommand;
using TMSAPI.Commands.TaskCommand;
using TMSAPI.Models;
using TMSAPI.Queries;
using TMSAPI.Repositories;

namespace TMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskListsController : ControllerBase
    {
        private readonly TMSContext _context;
        private readonly ITaskListRepository _taskListRepository;
        private readonly IMediator _mediator;
        private readonly ITMSQueries _TMSQueries;

        public TaskListsController(TMSContext context, ITaskListRepository taskListRepository, IMediator mediator, ITMSQueries tmsQueries)
        {
            _context = context;
            _taskListRepository = taskListRepository;
            _mediator = mediator;
            _TMSQueries = tmsQueries;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskList>>> GetTaskList()
        {
            //return await _context.TaskList.ToListAsync();
            var allresult = await _TMSQueries.GetAllTaskListByAsync();
            return Ok(allresult);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TaskList>> GetTaskListById(int id)
        {
            var getTaskListId = await _TMSQueries.GettaskListById(id);
            return Ok(getTaskListId);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskList(int id, TaskList taskList)
        {
            _taskListRepository.Update(taskList);

            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<TaskList>> PostTaskList(SaveTaskListCommand command)
        {
            var result = await _mediator.Send(command);
            return result;
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskList>> DeleteTaskList(int id)
        {
            var taskList = await _context.TaskList.FindAsync(id);
            if (taskList == null)
            {
                return NotFound();
            }

            _context.TaskList.Remove(taskList);
            await _context.SaveChangesAsync();

            return taskList;
        }
        [HttpGet("getalladdress")]
        public async Task<ActionResult<Address>> GetAllAddress()
        {
            var result = await _TMSQueries.GetAllAddressByAsync();
            return Ok(result);
        }

        [HttpGet("getallcar")]
        public async Task<ActionResult<Vehicle>> GetAllCar()
        {
            var result = await _TMSQueries.GetAllCarByAsync();
            return Ok(result);
        }

        [HttpGet("address/{id}")]
        public async Task<ActionResult<Address>> GetaddressById(int id)
        {
            var getTaskListId = await _TMSQueries.GetaddressById(id);
            return Ok(getTaskListId);
        }


        [HttpGet("vehicle/{id}")]
        public async Task<ActionResult<Address>> GetvehicleById(int id)
        {
            var getTaskListId = await _TMSQueries.GetvehicleById(id);
            return Ok(getTaskListId);
        }

        private bool TaskListExists(int id)
        {
            return _context.TaskList.Any(e => e.Id == id);
        }

        //=============================================Mobile=============================================
        [HttpGet("tasklist")]
        public async Task<IActionResult> GetAllTaskListAndAllDetailAsync()
        {
            var result = await _TMSQueries.GetAllTaskListAndAllDetailAsync();
            return Ok(result);
        }
        [HttpGet("tasklist/{accountId}")]
        public async Task<IActionResult> GetTaskListAndAllDetailBookedAsync(int accountId)
        {
            var result = await _TMSQueries.GetTaskListAndAllDetailBookedAsync(accountId);
            return Ok(result);
        }
        [HttpGet("tasklistBooked")]
        public async Task<IActionResult> GetAllTaskListAndAllDetailBookedAsync()
        {
            var result = await _TMSQueries.GetAllTaskListAndAllDetailBookedAsync();
            return Ok(result);
        }
        [HttpGet("tasklisProgress")]
        public async Task<IActionResult> GetAllTaskListAndAllDetailProgressAsync()
        {
            var result = await _TMSQueries.GetAllTaskListAndAllDetailInPorgressAsync();
            return Ok(result);
        }
        [HttpGet("tasklisProgress/{accountId}")]
        public async Task<IActionResult> GetTaskListAndAllDetailProgressAsync(int accountId)
        {
            var result = await _TMSQueries.GetTaskListAndAllDetailInPorgressAsync(accountId);
            return Ok(result);
        }

        [HttpGet("tasklistbytasknumber/{taskNumber}")]
        public async Task<IActionResult> GetTaskListByTaskNumber(string taskNumber)
        {
            var result = await _TMSQueries.GetTaskListByTaskNumber(taskNumber);
            return Ok(result);
        }

    }
}
