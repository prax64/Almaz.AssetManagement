using Almaz.AssetManagement.Infrastructure;
using Almaz.AssetManagement.Infrastructure.ModelConfigurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Almaz.AssetManagement.Infrastructure.ModelConfigurations
{
    /// <summary>
    /// Entity Type Configuration for entity Person
    /// </summary>
    public class ApplicationUserProfileModelConfiguration : AuditableModelConfigurationBase<ApplicationUserProfile>
    {
        protected override void AddBuilder(EntityTypeBuilder<ApplicationUserProfile> builder)
        {
            builder.HasOne(x => x.ApplicationUser);
        }

        protected override string TableName()
        {
            return "Profiles";
        }
    }
}