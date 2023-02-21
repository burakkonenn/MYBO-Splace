using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Application.DTOs.Language
{
    public class CreateLanguage
    {
        public string LangName { get; set; }
        public string LangCode { get; set; }
        public bool IsRtl { get; set; } = false;

    }
}
