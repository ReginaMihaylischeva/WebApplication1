using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestsTesk.Context
{
    public class Employee
    {
        public Employee()
        {
            this.Groups = new HashSet<Group>();
        }

        /// <summary>
        /// EmployeeId.
        /// </summary>
        [Required]
        public int EmployeeId { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Organisations.
        /// </summary>
        public Organisation Organisations { get; set; }

        /// <summary>
        /// Groups.
        /// </summary>
        [NotMapped]
        public virtual ICollection<Group> Groups { get; set; }

    }
}