using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities.Common;
using Web.Domain.Entities.Identity;

namespace Web.Domain.Entities.Design
{
    public class DesignFont : BaseEntity
    {
        public string Name { get; set; }
        public string FontFamily { get; set; }
        public string FontSrc { get; set; }




        public ICollection<AppUser> AppUsers { get; set; }



    }
}
