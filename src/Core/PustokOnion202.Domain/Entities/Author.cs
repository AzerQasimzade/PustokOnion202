using PustokOnion202.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PustokOnion202.Domain.Entities
{
    public class Author:BaseNameableEntity
    {
        public ICollection<BookTag>? Booktags { get; set; }
    }
}
