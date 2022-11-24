using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Tibas.Domain.Entities;
public class Favourite
{
    public int Id { get; set; }

    public long GitHubId { get; set; }

    public string GitHubName { get; set; }

    public string GitOwnerName { get; set; }

    public string Description { get; set; }

    public string UserId { get; set; }
} 