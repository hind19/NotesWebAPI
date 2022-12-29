namespace Notes.Application.Exceptions
{
    /// <summary>
    /// Provides Custom Exception for Entity Not Found error.
    /// </summary>
    public class EntityNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotFoundException"/> class.
        /// </summary>
        /// <param name="name">Name of entity.</param>
        /// <param name="key">Search key.</param>
        public EntityNotFoundException(string name, object key)
            : base($"Entity \"{name}\" ({key}) is not found")
        {
        }
    }
}
