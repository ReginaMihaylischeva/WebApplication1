using System.ComponentModel.DataAnnotations;

namespace TestsTesk.Context
{
    public class Course
    {
        /// <summary>
        /// Course id.
        /// </summary>
        [Required]
        public int CourseId { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Group.
        /// </summary>
        public virtual Group Group { get; set; }

    }
}