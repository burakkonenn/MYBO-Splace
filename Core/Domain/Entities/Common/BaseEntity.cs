using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Domain.Entities.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public DateTime? UpdatedTime { get; set; } = null;
        public DateTime? DeletedTime { get; set; } = null;


        public bool IsDelete { get; set; } = false;
        public bool IsActive { get; set; } = true;






    }
}
