using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace UkolnikBackend.Models
{
    public class Users
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }

    public class Tasks
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string? Status { get; set; }

        public DateTime? Deadline { get; set; }

        public string? Creator { get; set; }
    }

    public class Comments
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        public string Creator { get; set; }

        public int TaskId { get; set; }

        public DateTime? Created { get; set; }
    }
}
