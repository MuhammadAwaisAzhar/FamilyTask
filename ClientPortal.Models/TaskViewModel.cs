using System;
using System.Collections.Generic;
using System.Text;

namespace ClientPortal.Models
{
    public class TaskViewModel
    {
        public Guid? TaskId { get; set; }
        public string Subject { get; set; }
        public Boolean IsComplete { get; set; }
        public Guid? AssignedMemeberId { get; set; }
    }
}
