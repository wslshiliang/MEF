using System.Data.Entity.ModelConfiguration;

namespace EntityModel.Sys
{
    public class RoleConfiguration: Base_Configuration<RoleModel>
    {
        public override void Configuration(EntityTypeConfiguration<RoleModel> config)
        {
            base.Configuration(config);
            ToTable("SYS_ROLE");
            Property(p => p.Name).HasColumnName("F_NAME").HasMaxLength(50).IsRequired();
        }
    }
}
