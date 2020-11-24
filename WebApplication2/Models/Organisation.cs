namespace TestsTesk.Context
{
    public class Organisation
    {

        /// <summary>
        /// OrganisationId.
        /// </summary>
        public int OrganisationId { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// INN.
        /// </summary>
        public string INN { get; set; }
        public virtual Teacher Teacher { get; set; }

    }
}