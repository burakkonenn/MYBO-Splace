using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities.Common;
using Web.Domain.Entities.Identity;

namespace Web.Domain.Entities.Design
{
    public class SocialMedia : BaseEntity
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string Platform { get; set; }


        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }


    }
}
