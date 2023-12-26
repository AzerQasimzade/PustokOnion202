using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PustokOnion202.Domain.Entities.Common
{
    public class BaseNameableEntity:BaseEntity
    {
        public string Name { get; set; } = null!;
    }
}
