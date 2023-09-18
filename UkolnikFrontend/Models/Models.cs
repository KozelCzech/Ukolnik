using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UkolnikFrontend.Models
{
    public class Users
    {
        public int id { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public string email { get; set; }
    }

    public class Tasks
    {
        public int id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public string? status { get; set; }

        public DateTime? deadline { get; set; }

        public string? creator { get; set; }
    }

    public class Comments
    {
        public int id { get; set; }

        public string name { get; set; }

        public string text { get; set; }

        public string creator { get; set; }

        public int taskId { get; set; }

        public DateTime? created { get; set; }
    }
}
