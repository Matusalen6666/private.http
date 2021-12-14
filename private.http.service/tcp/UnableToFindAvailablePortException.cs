using System;

namespace @private.http.service.tcp
{
    /// <summary>
    /// Thrown when no port could be found to bind to
    /// </summary>
    internal class UnableToFindAvailablePortException: Exception
    {
        /// <inheritdoc />
        public UnableToFindAvailablePortException():
            base("Can't find a port to listen on ):")
        {
        }
    }
}