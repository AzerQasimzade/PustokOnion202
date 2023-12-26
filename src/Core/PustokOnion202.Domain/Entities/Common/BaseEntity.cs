using PustokOnion202.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PustokOnion202.Domain.Entities.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public int IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; } 
        public string CreatedBy { get; set; } = null!;
        public BaseEntity()
        {
            CreatedBy = "azer.qasymov";
            CreatedAt = DateTime.Now;
            ModifiedAt = DateTime.Now;
        }

    }
}
