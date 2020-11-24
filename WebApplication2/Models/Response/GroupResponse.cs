using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestsTesk.Models.Response
{
    public class GroupResponse
    {
        /// <summary>
        /// Name.
        /// </summary>
        /// 
        public int Id { get; set; }

        public string Name { get; set; }

        public int CountStudents { get; set; }

        public string TeacherName { get; set; }

    }
}