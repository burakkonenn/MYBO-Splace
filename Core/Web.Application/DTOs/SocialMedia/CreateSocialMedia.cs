using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Application.DTOs.SocialMedia
{
    public class CreateSocialMedia
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string Platform { get; set; }
        public Guid AppUserId { get; set; }

    }
}
