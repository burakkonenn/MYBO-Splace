using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Application.DTOs.Design.DesignFont
{
    public class PostUpdateDesignFont
    {
        public Guid DesignFontId { get; set; }
        public string Name { get; set; }
        public string FontFamily { get; set; }
        public string FontSrc { get; set; }

    }
}
