namespace GamerLibrary.Common.Core.Domain
{
    public class BaseEntity
    {
        /// <summary>
        /// Uniquely identifier of the entity
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// UTC Datetime where the entity was created
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Last UTC Datetime where the entity was updated
        /// </summary>
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// UTC Datetime where the entity was deleted
        /// </summary>
        public DateTime? DeletedDate { get; set; }
    }
}
