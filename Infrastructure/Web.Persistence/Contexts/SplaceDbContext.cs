using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities.Brief;
using Web.Domain.Entities.Common;
using Web.Domain.Entities.Culture;
using Web.Domain.Entities.Design;
using Web.Domain.Entities.Identity;

namespace Web.Persistence.Contexts
{

    public class SplaceDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public SplaceDbContext(DbContextOptions options) : base(options)
        { }


        #region Brief
        public DbSet<Link> Links { get; set; }
        #endregion

        #region Culture
        public DbSet<Language> Languages { get; set; }
        public DbSet<Word> Words { get; set; }
        #endregion

        #region Design
        public DbSet<DesignBackground> DesignBackgrounds { get; set; }
        public DbSet<DesignButton> DesignButtons { get; set; }
        public DbSet<DesignFont> DesignFonts { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        #endregion






        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker
                 .Entries<BaseEntity>();

            // TODO Tüm sorgularda isDeleted değilse gelecek

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    // TODO Burada silme işleminde IsDelete true eklencek.

                    EntityState.Added => data.Entity.CreatedTime = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedTime = DateTime.UtcNow,
                    EntityState.Deleted => data.Entity.DeletedTime = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
