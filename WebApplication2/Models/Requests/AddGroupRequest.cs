using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestsTesk.Models.Requests
{
    public class AddGroupRequest
    {
        /// <summary>
        /// Teacher.
        /// </summary>
        public int TeacherId { get; set; }

        public string Name { get; set; }

    }
}