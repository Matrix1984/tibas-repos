using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tibas.Domain.ValueObjects;
public class JWTokenOptions
{
    public string SecretKey { get; set; }

    public string Issuer { get; set; }

    public string Audience { get; set; }
} 