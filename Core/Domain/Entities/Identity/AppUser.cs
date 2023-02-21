using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities.Brief;
using Web.Domain.Entities.Culture;
using Web.Domain.Entities.Design;

namespace Web.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<Guid>
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Biography { get; set; }
        public string Avatar { get; set; }
        public string Slug { get; set; }

        public int Famous { get; set; } // 0- Normal 1- Mavi Tikli 2- Sarı Tikli
        public int AccountType { get; set; } // 0 - 1 - 2


        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }


        public string FacebookPixelId { get; set; }
        public string FacebookConversionId { get; set; }
        public string GoogleAnalyticsId { get; set; }

        public Guid LanguageId { get; set; }
        public Language? Language { get; set; }





        public ICollection<SocialMedia> SocialMedias { get; set; }
        public ICollection<Link> Links { get; set; }


        public Guid? DesignBackgroundId { get; set; }
        public DesignBackground DesignBackground { get; set; }

        public Guid? DesignFontId { get; set; }
        public DesignFont DesignFont { get; set; }

        public Guid? DesignButtonId { get; set; }
        public DesignButton DesignButton { get; set; }
    }
}
