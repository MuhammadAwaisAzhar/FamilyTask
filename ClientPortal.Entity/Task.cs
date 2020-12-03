using System;
using System.Collections.Generic;
using System.Text;

namespace ClientPortal.Entities
{
    public class Task
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public Boolean IsComplete { get; set; }
        public Guid? AssignedMemeberId { get; set; }
        public Member AssignedMember { get; set; }
    }
}
