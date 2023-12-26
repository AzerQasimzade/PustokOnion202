using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PustokOnion202.Application.DTOs.Book
{
    public record BookItemDto(int id, string name, decimal price,decimal discount);
}
