using System;
using System.Reflection;

namespace Chef.BLL.Exceptions
{
    public class NullDtoException : Exception
    {
        public NullDtoException(MemberInfo type) : base($"Cannot operate with null {type.Name} DTO")
        { }
    }
}
