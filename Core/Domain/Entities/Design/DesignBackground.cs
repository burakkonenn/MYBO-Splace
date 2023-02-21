using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities.Common;
using Web.Domain.Entities.Identity;

namespace Web.Domain.Entities.Design
{
    public class DesignBackground : BaseEntity
    {

        public string Title { get; set; }
        public string Wallpaper { get; set; }
        public int GradientType { get; set; } // 0 Yok, 1 Linear 2 Radial 
        public string GradientColor1 { get; set;}
        public string GradientColor2 { get; set; }
        public string BackgroundColor { get; set; }


        public bool IsSystem { get; set; } = false;


        public ICollection<AppUser> AppUsers { get; set; }


    }
}
