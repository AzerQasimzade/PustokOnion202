using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PustokOnion202.Application.DTOs.Book
{
    public record CreateBookDto(string Name, decimal Price, string? Description, string SKU, int GenreId, int AuthorId, ICollection<int>? TagIds);
    
}
