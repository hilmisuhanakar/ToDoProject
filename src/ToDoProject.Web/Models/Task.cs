using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace ToDoProject.Web.Models
{
    public partial class Task
    {
        public int Id { get; set; }

        [DisplayName("Kullanıcı")]
        public int UserId { get; set; }

        [DisplayName("Tarih")]
        public DateTime TaskDate { get; set; }

        [DisplayName("Görev İsmi")]
        public string TaskName { get; set; }

        [DisplayName("Görev açıklaması")]
        public string TaskDescription { get; set; }

        [DisplayName("Kullanıcı")]
        public virtual User User { get; set; }
    }
}
