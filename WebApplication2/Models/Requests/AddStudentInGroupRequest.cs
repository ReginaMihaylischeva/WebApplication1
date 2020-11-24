using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestsTesk.Context;

namespace WebApplication2.Models.Requests
{
    public class AddStudentInGroupRequest
    {
        public string groupName { get; set; }

        public int groupId { get; set; }

        public string teacherName { get; set; }

        public List<Organisation> Organisations { get; set; }

        public List<Employee> Employees { get; set; }

    }
}
