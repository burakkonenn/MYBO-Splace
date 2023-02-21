using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities.Common;
using Web.Domain.Entities.Identity;

namespace Web.Domain.Entities.Design
{
    public class DesignButton : BaseEntity
    {
        public string Title { get; set; }
        public string TextColor { get; set; }
        public string BgColor { get; set; }
        public string BorderColor { get; set; }
        public string ShadowColor { get; set; }


        public bool IsSystem { get; set; } = false;

        public ICollection<AppUser> AppUsers { get; set; }
    }
}
