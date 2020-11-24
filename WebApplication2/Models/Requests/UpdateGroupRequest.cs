using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestsTesk.Models.Requests
{
    public class UpdateGroupRequest
    {
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// GroupId.
        /// </summary>
        public int GroupId { get; set; }

    }
}