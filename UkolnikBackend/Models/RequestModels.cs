using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UkolnikBackend.Models
{
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UpdateTaskRequest
    {
        public int taskId { get; set; }
        public string Status { get; set; }
    }

    public class EditTaskRequest
    {
        public int taskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? Deadline { get; set; }
    }

    public class DeleteTaskRequest
    {
        public int taskId { get; set; }
    }

    public class DeleteCommentRequest
    {
        public int commentId { get; set; }
    }
}
