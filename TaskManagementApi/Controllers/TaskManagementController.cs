using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TaskManagementApi.Models;
using TaskManagementApi.Models.DTO;
using TaskManagementApi.Repository.IRepository;

namespace TaskManagementApi.Controllers
{
    [Route("api/task")]
    [ApiController]
    [Authorize]
    public class TaskManagementController : Controller
    {
        protected ApiResponse _response;
        private readonly IMapper _mapper;
        private readonly IProjectTaskRepository db;
        public TaskManagementController(IMapper _mapper, IProjectTaskRepository taskRepo)
        {
            _response = new();
            this._mapper = _mapper;
            db = taskRepo;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse>> GetAll()
        {
            try
            {
                IEnumerable<ProjectTask> projectTasks = await db.GetAll();
                _response.result = _mapper.Map<List<ProjectTaskDTO>>(projectTasks);
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                ApiResponse.FailedResponse(_response, ex);
            }
            return _response;
        }

        [HttpGet("{id:int}",Name ="GetTask")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse>> Get(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = new List<string>() { "There is no ProjectTask with 0 ID" };
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }
                var projectTask =await db.Get(task => task.Id == id);
                if (projectTask == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string>() { $"There is no ProjectTask with {id} ID" };
                }
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;
                _response.result = _mapper.Map<ProjectTaskDTO>(projectTask);
                return Ok(_response);
            }
            catch (Exception ex)
            {
                ApiResponse.FailedResponse(_response, ex);
            }
            return _response;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse>> Create([FromBody] ProjectTaskCreateDTO taskCreate)
        {
            try
            {
                if(taskCreate == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess=false;
                    _response.ErrorMessages = new List<string>() { "Task Was NULL, nothing can not be created :)" };
                    return BadRequest(_response);
                }
                if(await db.Get(task => task.Name.ToLower() == taskCreate.Name.ToLower()) != null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string>() { "Task was alreade created" };
                    return BadRequest(_response);
                }
                ProjectTask projectTask=_mapper.Map<ProjectTask>(taskCreate);
                await db.Create(projectTask);
                _response.StatusCode = HttpStatusCode.Created;
                _response.result = _mapper.Map<ProjectTaskDTO>(projectTask);
                _response.IsSuccess=true;
                return CreatedAtRoute("GetTask", new { id = projectTask.Id }, _response);
            }catch(Exception ex)
            {
                ApiResponse.FailedResponse(_response, ex);
            }
            return _response;
        }


        [HttpDelete("{id:int}", Name = "DeleteTask")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse>> DeleteTask(int id)
        {
            try
            {
                if(id==0)
                {
                    ApiResponse.SuccessResponse(_response, HttpStatusCode.BadRequest, false, "There is not ProjectTask" +
                        "with Id=0", null);
                    return BadRequest(_response);
                }
                var projectTask=await db.Get(task=>task.Id==id);
                if (projectTask == null)
                {
                    ApiResponse.SuccessResponse(_response, HttpStatusCode.NotFound, false, "There is not ProjectTask" +
                        $"with Id {id}", null);
                    return NotFound(_response);
                }
                await db.Remove(projectTask);
                ApiResponse.SuccessResponse(_response, HttpStatusCode.NoContent, true, null, null);
                return Ok(_response);  
            }
            catch(Exception ex)
            {
                ApiResponse.FailedResponse(_response,ex);
            }
            return _response;
        }

        [HttpPut("{id:int}", Name = "UpdateTask")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse>> UpdateTask(int id, [FromBody] ProjectTaskUpdateDTO updateTask)
        {
            try
            {
                if (id == 0 || updateTask==null)
                {
                    ApiResponse.SuccessResponse(_response, HttpStatusCode.BadRequest, false, "Id can note be zero and update " +
                        "task can not be null!!!", null);
                    return BadRequest(_response);
                }
                bool taskExists = (await db.Get(task => task.Id == id,tracked:false)) == null;
                if(taskExists)
                {
                    ApiResponse.SuccessResponse(_response, HttpStatusCode.NotFound, false, "There is not ProjectTask" +
                        $"with Id {id}", null);
                    return NotFound(_response);
                }
                ProjectTask projectTask=_mapper.Map<ProjectTask>(updateTask);
                projectTask.Id = id;
                await db.Update(projectTask);
                ProjectTaskDTO result=_mapper.Map<ProjectTaskDTO>(projectTask);
                ApiResponse.SuccessResponse(_response, HttpStatusCode.NoContent, true, null, result);
                return Ok(_response);
            }
            catch(Exception ex)
            {
                ApiResponse.FailedResponse(_response, ex);
            }
            return _response;
        }

    }
}
