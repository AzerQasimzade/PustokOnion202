using PustokOnion202.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PustokOnion202.Domain.Entities
{
    public class BookTag:BaseEntity
    {
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; } 
    }
}
