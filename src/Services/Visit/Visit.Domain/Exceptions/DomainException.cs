

namespace Visit.Domain.Exceptions;

    public class DomainException : Exception
    {
    public DomainException( string messsage ) : base ($"Domain Exception: \"{messsage}\" throw from Domain Layer Visit.")
    { }

    }

