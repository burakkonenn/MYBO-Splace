using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Application.DTOs.Design.DesignBackground
{
    public class GetUpdateDesignBackground
    {
        public string Title { get; set; }
        public string Wallpaper { get; set; }
        public int GradientType { get; set; } // 0 Yok, 1 Linear 2 Radial 
        public string GradientColor1 { get; set; }
        public string GradientColor2 { get; set; }
        public string BackgroundColor { get; set; }
    }
}
