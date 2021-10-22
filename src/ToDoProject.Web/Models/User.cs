using System;
using System.Collections.Generic;
using System.ComponentModel;

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

        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }

        [DisplayName("Kullanıcı Şifresi")]
        public string UserPassword { get; set; }

        [DisplayName("İsim")]
        public string Name { get; set; }

        [DisplayName("Soyisim")]
        public string Surname { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
