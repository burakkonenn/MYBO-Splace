using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities.Common;
using Web.Domain.Entities.Identity;

namespace Web.Domain.Entities.Culture
{
    public class Language : BaseEntity
    {
        public string LangName { get; set; }
        public string LangCode { get; set; } = "tr";
        public bool IsRtl { get; set; } = false;



        public ICollection<Word> Words { get; set; }
        public ICollection<AppUser> AppUser { get; set; }
    }
}
