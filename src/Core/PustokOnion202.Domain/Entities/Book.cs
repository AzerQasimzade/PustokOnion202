using PustokOnion202.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PustokOnion202.Domain.Entities
{
    public class Book:BaseNameableEntity
    {
        public string? Desc { get; set; }
        public int Page { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public Genre  Genre { get; set; }
        public int GenreId { get; set; }
        public ICollection<BookTag> BookTags { get; set; }


    }
}
