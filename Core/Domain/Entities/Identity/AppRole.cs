using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Domain.Entities.Identity
{
    public class AppRole : IdentityRole<Guid>
    {
        public string GroupName { get; set; }
        public bool IsAdmin { get; set; } // 0 Free - 1 9.90 User 99-> Admin
    }
}
