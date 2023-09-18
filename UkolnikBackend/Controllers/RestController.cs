using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using UkolnikBackend.Models;

namespace UkolnikBackend.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class RestController : ControllerBase
    {
        private readonly UserService _userService;

        public RestController(UserService userService)
        {
            _userService = userService;
        }

        //User Registration
        [HttpPost]
        [Route("register")]
        public IActionResult RegisterUser([FromBody] Users user)
        {
            try
            {
                Console.WriteLine($"User registered: Username - {user.Username}, Email - {user.Email}");
                _userService.RegisterUser(user);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        //User Login
        [HttpPost]
        [Route("login")]
        public IActionResult LoginUser([FromBody] LoginRequest loginRequest)
        {
            try
            {
                Console.WriteLine($"User logged in: Username - {loginRequest.Username}");
                var user = _userService.LoginUser(loginRequest.Username, loginRequest.Password);
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("getLoggedInUser")]
        public IActionResult GetLoggedInUser()
        {
            try
            {
                var user = _userService.GetLoggedInUser();
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //Task Creation
        [HttpPost]
        [Route("createTask")]
        public IActionResult CreateTask([FromBody] Tasks task)
        {
            try
            {
                Console.WriteLine($"Task created: Task name - {task.Name}");
                _userService.CreateTask(task);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //send all tasks to frontend
        [HttpGet]
        [Route("getAllTasks")]
        public IActionResult GetAllTasks()
        {
            try
            {
                var tasks = _userService.GetAllTasks();
                return Ok(tasks);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //update task status
        [HttpPost]
        [Route("updateTask")]
        public IActionResult UpdateTask([FromBody] UpdateTaskRequest updateTaskRequest)
        {
            try
            {
                Console.WriteLine($"Task updated: Task id - {updateTaskRequest.taskId}, new status - {updateTaskRequest.Status}");
                _userService.UpdateTask(updateTaskRequest);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //edit task
        [HttpPost]
        [Route("editTask")]
        public IActionResult EditTask([FromBody] EditTaskRequest editTaskRequest)
        {
            try
            {
                Console.WriteLine($"Task edited: Task id - {editTaskRequest.taskId}, new name - {editTaskRequest.Name}, new description - {editTaskRequest.Description}, new date - {editTaskRequest.Deadline}");
                _userService.EditTask(editTaskRequest);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //delete task
        [HttpPost]
        [Route("deleteTask")]
        public IActionResult DeleteTask([FromBody] DeleteTaskRequest deleteTaskRequest)
        {
            try
            {
                Console.WriteLine($"Task deleted: Task id - {deleteTaskRequest.taskId}");
                _userService.DeleteTask(deleteTaskRequest.taskId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //create comment
        [HttpPost]
        [Route("createComment")]
        public IActionResult CreateComment([FromBody] Comments comment)
        {
            try
            {
                Console.WriteLine($"Comment created: Comment text - {comment.Text}");
                _userService.CreateComment(comment);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //get all comments
        [HttpGet]
        [Route("getAllComments")]
        public IActionResult GetAllComments()
        {
            try
            {
                var comments = _userService.GetAllComments();
                return Ok(comments);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //delete comment
        [HttpPost]
        [Route("deleteComment")]
        public IActionResult DeleteComment([FromBody] DeleteCommentRequest deleteCommentRequest)
        {
            try
            {
                Console.WriteLine($"Comment deleted: Comment id - {deleteCommentRequest.commentId}");
                _userService.DeleteComment(deleteCommentRequest.commentId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
