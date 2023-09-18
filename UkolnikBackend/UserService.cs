using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using UkolnikBackend.Models;

namespace UkolnikBackend
{
    public class UserService
    {
        private readonly LiteDatabase _liteDatabase;
        private Models.Users? _user;

        public UserService(LiteDatabase liteDatabase)
        {
            _liteDatabase = liteDatabase;
            _user = null;
        }


        //User Functionality ----------------------------------------------
        public void RegisterUser(Models.Users user)
        {
            try
            {
                var usersCollection = _liteDatabase.GetCollection<Models.Users>("Users");
                usersCollection.Insert(user);
            }
            catch (LiteException ex)
            {
                // Handle the exception (e.g., log it or throw a custom exception)
                Console.WriteLine($"LiteDB Error: {ex.Message}");
                throw;
            }
        }

        public Models.Users LoginUser(string username, string password)
        {
            try
            {
                var usersCollection = _liteDatabase.GetCollection<Models.Users>("Users");
                var user = usersCollection.FindOne(x => x.Username == username && x.Password == password);
                if (user == null)
                {
                    throw new Exception("User not found");
                }
                else
                    _user = user;

                return user;
            }
            catch (LiteException ex)
            {
                // Handle the exception (e.g., log it or throw a custom exception)
                Console.WriteLine($"LiteDB Error: {ex.Message}");
                throw;
            }
        }
        public Models.Users GetLoggedInUser()
        {
            if(_user != null)
                return _user;
            else
                throw new Exception("User not logged in");
        }

        //Task Functionality ----------------------------------------------

        public void CreateTask(Models.Tasks task)
        {
            try
            {
                var tasksCollection = _liteDatabase.GetCollection<Models.Tasks>("Tasks");
                tasksCollection.Insert(task);
            }
            catch (LiteException ex)
            {
                // Handle the exception (e.g., log it or throw a custom exception)
                Console.WriteLine($"LiteDB Error: {ex.Message}");
                throw;
            }
        }

        public List<Models.Tasks> GetAllTasks()
        {
            try
            {
                var tasksCollection = _liteDatabase.GetCollection<Models.Tasks>("Tasks");
                var tasks = tasksCollection.FindAll().ToList();
                return tasks;
            }
            catch (LiteException ex)
            {
                Console.WriteLine($"LiteDB Error: {ex.Message}");
                throw;
            }
        }

        public void UpdateTask(UpdateTaskRequest updateTaskRequest)
        {
            try
            {
                var tasksCollection = _liteDatabase.GetCollection<Models.Tasks>("Tasks");
                var existingTask = tasksCollection.FindOne(x => x.Id == updateTaskRequest.taskId);


                if (existingTask == null)
                {
                    throw new Exception("Task not found");
                }
                else
                {
                    //Console.WriteLine($"Task updated: Task name - {existingTask.Name}");
                    existingTask.Status = updateTaskRequest.Status;
                    tasksCollection.Update(existingTask);
                }
            }
            catch (LiteException ex)
            {
                Console.WriteLine($"LiteDB Error: {ex.Message}");
                throw;
            }
        }

        public void EditTask(EditTaskRequest editTaskRequest)
        {
            try
            {
                var tasksCollection = _liteDatabase.GetCollection<Models.Tasks>("Tasks");
                var existingTask = tasksCollection.FindOne(x => x.Id == editTaskRequest.taskId);
                if (existingTask == null)
                {
                    throw new Exception("Task not found");
                }
                else
                {
                    //Console.WriteLine($"Task updated: Task name - {existingTask.Name}");
                    existingTask.Name = editTaskRequest.Name;
                    existingTask.Description = editTaskRequest.Description;
                    existingTask.Deadline = editTaskRequest.Deadline;
                    tasksCollection.Update(existingTask);
                }
            }
            catch (LiteException ex)
            {
                Console.WriteLine($"LiteDB Error: {ex.Message}");
                throw;
            }
        }

        public void DeleteTask(int taskId)
        {
            try
            {
                var tasksCollection = _liteDatabase.GetCollection<Models.Tasks>("Tasks");
                var existingTask = tasksCollection.FindOne(x => x.Id == taskId);
                if (existingTask == null)
                {
                    throw new Exception("Task not found");
                }
                else
                {
                    tasksCollection.Delete(taskId);
                }
            }
            catch (LiteException ex)
            {
                Console.WriteLine($"LiteDB Error: {ex.Message}");
                throw;
            }
        }

        //comment user service ----------------------------------------------

        public void CreateComment(Comments comments)
        {
            try
            {
                var commentsCollection = _liteDatabase.GetCollection<Comments>("Comments");
                commentsCollection.Insert(comments);
            }
            catch (LiteException ex)
            {
                Console.WriteLine($"LiteDB Error: {ex.Message}");
                throw;
            }
        }

        public List<Comments> GetAllComments()
        {
            try
            {
                var commentsCollection = _liteDatabase.GetCollection<Comments>("Comments");
                var comments = commentsCollection.FindAll().ToList();
                return comments;
            }
            catch (LiteException ex)
            {
                Console.WriteLine($"LiteDB Error: {ex.Message}");
                throw;
            }
        }

        public void DeleteComment(int commentId)
        {
            try
            {
                var commentsCollection = _liteDatabase.GetCollection<Comments>("Comments");
                var existingComment = commentsCollection.FindOne(x => x.Id == commentId);
                if (existingComment == null)
                {
                    throw new Exception("Comment not found");
                }
                else
                {
                    commentsCollection.Delete(commentId);
                }
            }
            catch (LiteException ex)
            {
                Console.WriteLine($"LiteDB Error: {ex.Message}");
                throw;
            }
        }
    }
}
