using System.Collections.Generic;

namespace TestsTesk.Context
{
    public class Group
    {
        public Group()
        {
            this.Employes = new List<Employee>();
        }

        /// <summary>
        /// GroupId.
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Teachers.
        /// </summary>
        public virtual Teacher Teachers { get; set; }

        /// <summary>
        /// Employes.
        /// </summary>
        public virtual ICollection<Employee> Employes { get; set; }
    }
}