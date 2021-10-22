using System;
using System.Collections.Generic;

#nullable disable

namespace ToDoProject.Web.Models
{
    public partial class User
    {
        public User()
        {
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
