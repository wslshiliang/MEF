using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Sys
{
  public  class RoleModuleConfiguration:Base_Configuration<RoleModuleModel>
    {
        public override void Configuration(EntityTypeConfiguration<RoleModuleModel> config)
        {
            base.Configuration(config);
            ToTable("SYS_ROLE_MODULE");
            Property(p => p.RoleId).HasColumnName("F_ROLEID").IsRequired();
            Property(p => p.ModuleId).HasColumnName("F_MODULEID").IsRequired();

            HasRequired(p => p.Role).WithMany(r => r.RoleModules).HasForeignKey(p => p.RoleId).WillCascadeOnDelete(true);
            HasRequired(p => p.Module).WithMany(r => r.ModuleRole).HasForeignKey(p => p.ModuleId).WillCascadeOnDelete(true);
        }
    }
}
