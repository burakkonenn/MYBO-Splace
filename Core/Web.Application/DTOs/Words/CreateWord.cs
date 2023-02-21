using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Application.DTOs.Words
{
    public class CreateWord
    {
        public string WordKey { get; set; }
        public string WordValue { get; set; }
        public Guid LanguageId { get; set; }

    }
}
