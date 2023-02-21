using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Application.DTOs.User
{
    public class CreateUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Biography { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public string Slug { get; set; }
        public int Famous { get; set; } 
        public int AccountType { get; set; } 
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string FacebookPixelId { get; set; }
        public string FacebookConversionId { get; set; }
        public string GoogleAnalyticsId { get; set; }
        public Guid DesignBackgroundId { get; set; }
        public Guid DesignFontId { get; set; }
        public Guid DesignButtonId { get; set; }

    }
}
