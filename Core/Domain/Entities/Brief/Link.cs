using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities.Common;
using Web.Domain.Entities.Identity;

namespace Web.Domain.Entities.Brief
{
    public class Link : BaseEntity
    {
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }




        public string Avatar { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }




        public DateTime? StartTimer { get; set; }
        public DateTime? FinishTimer { get; set; }
        public bool IsTimer { get; set; } = false;



        public bool IsSensitive { get; set; }
        public int ListNumber { get; set; }


    }
}
