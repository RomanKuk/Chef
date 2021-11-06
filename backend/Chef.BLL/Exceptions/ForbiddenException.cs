using System;

namespace Chef.BLL.Exceptions
{
    public sealed class ForbiddenException : Exception
    {
        public ForbiddenException(string operation, string entity, int id)
            : base($"You do not have access to {operation} entity {entity} with id ({id})")
        {
        }
        public ForbiddenException(string message) : base(message) { }
        public ForbiddenException() : base("You do not have access") { }
    }
}
