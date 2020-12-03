using System;
using System.Collections.Generic;
using System.Text;

namespace ClientPortal.Entities
{
    public class Member
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Roles { get; set; }
        public string Avatar { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
