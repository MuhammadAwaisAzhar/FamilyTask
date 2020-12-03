using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClientPortal.Models;
using ClientPortal.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClientPortal.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasksService _tasksService;
        public TasksController(ITasksService tasksService)
        {
            this._tasksService = tasksService;
        }
        // GET: api/<Tasks>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskViewModel>>> Get()
        {
            try
            {
                return Ok(await _tasksService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong, please try again!" + ex.Message);
            }

        }

        // GET api/<Tasks>/5
        [HttpGet, Route("{id}")]
        public async Task<ActionResult<TaskViewModel>> Get(Guid id)
        {
            try
            {
                var taskFound = await _tasksService.GetByIdAsync(id);
                if (taskFound == null)
                {
                    return BadRequest("Task not found, please check Id and try again.!");
                }
                return Ok(taskFound);
            }
            catch (Exception ex)
            {
                return BadRequest("Somthing went wrong, Please try again later" + ex.Message);
            }
        }
        // POST api/<Tasks>
        [HttpPost]
        public async Task<ActionResult<MemberViewModel>> Post(TaskViewModel taskViewModel)
        {
            try
            {
                var createdTask = await _tasksService.AddAsync(taskViewModel);
                return CreatedAtAction("Get", new { id = taskViewModel.TaskId }, createdTask);
            }
            catch (Exception ex)
            {
                return BadRequest("Somthing went wrong, Please try again later" + ex.Message);
            }

        }
        // PUT: api/Tasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, TaskViewModel taskViewModel)
        {
            try
            {
                if (id != taskViewModel.TaskId)
                {
                    return BadRequest("Task Id is not valid, Please try with valid information.!");
                }
                var updatedTask = await _tasksService.updateAsync(taskViewModel, id);

                if (updatedTask == null)
                    return NoContent();
                else
                    return Ok(updatedTask);
            }
            catch (Exception ex)
            {
                return BadRequest("Somthing went wrong, Please try again later" + ex.Message);
            }

        }
        // PUT: api/Tasks/5/AssignmentOfTask
        [HttpPut,Route("{id}/AssignmentOfTask")]
        public async Task<IActionResult> AssignmentOfTask(Guid id, TaskViewModel taskViewModel)
        {
            try
            {
                if (id != taskViewModel.TaskId)
                {
                    return BadRequest("Task Id is not valid, Please try with valid information.!");
                }
                var updatedTask = await _tasksService.updateAsync(taskViewModel, id);

                if (updatedTask == null)
                    return NoContent();
                else
                    return Ok(updatedTask);
            }
            catch (Exception ex)
            {
                return BadRequest("Somthing went wrong, Please try again later" + ex.Message);
            }

        }
        // DELETE api/<Tasks>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            try
            {
                await _tasksService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Somthing went wrong, Please try again later" + ex.Message);
            }
        }

        [HttpGet, Route("{memeberId}/GetAssignedTaskOfMember")]
        public async Task<ActionResult<TaskViewModel>> GetAssignedTaskOfMember(Guid memeberId)
        {
            try
            {
                var taskFound = await _tasksService.GetAssignedTasksOfMemberAsync(memeberId);
                if (taskFound == null)
                {
                    return BadRequest("Tasks against member Id specified not found, please check Id and try again.!");
                }
                return Ok(taskFound);
            }
            catch (Exception ex)
            {
                return BadRequest("Somthing went wrong, Please try again later" + ex.Message);
            }
        }
    }
}
