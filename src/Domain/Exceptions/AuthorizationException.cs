using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tibas.Domain.Exceptions;
public class AuthorizationException : Exception
{
    public AuthorizationException(string description)
        : base(description)
    {
    }
}
