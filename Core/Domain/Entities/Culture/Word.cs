using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities.Common;

namespace Web.Domain.Entities.Culture
{
    public class Word : BaseEntity
    {
        public string WordKey { get; set; }
        public string WordValue { get; set; }


        public Guid LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
