using System;
using System.Collections.Generic;
using System.Text;

namespace ClientPortal.Models
{
    public class MemberViewModel
    {
        public Guid? MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Roles { get; set; }
        public string Avatar { get; set; }
        public IEnumerable<TaskViewModel> Tasks { get; set; }
    }
}
