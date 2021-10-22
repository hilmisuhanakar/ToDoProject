using System;
using System.Collections.Generic;

#nullable disable

namespace ToDoProject.Web.Models
{
    public partial class Task
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime TaskDate { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }

        public virtual User User { get; set; }
    }
}
