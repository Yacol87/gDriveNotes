using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public User() { }
        private User(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
    }
}
