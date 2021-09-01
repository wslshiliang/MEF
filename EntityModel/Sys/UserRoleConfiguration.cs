using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Sys
{
   public class UserRoleConfiguration:Base_Configuration<UserRoleModel>
    {
        public override void Configuration(EntityTypeConfiguration<UserRoleModel> config)
        {
            base.Configuration(config);
            ToTable("SYS_USER_ROLE");

            Property(p => p.UserId).HasColumnName("F_USERID").IsRequired();
            Property(p => p.RoleId).HasColumnName("F_ROLEID").IsRequired();

            HasRequired(p => p.User).WithMany(p => p.UserRole).HasForeignKey(p => p.UserId).WillCascadeOnDelete(false);
            HasRequired(p => p.Role).WithMany(p => p.UserRole).HasForeignKey(p => p.RoleId).WillCascadeOnDelete(false);
        }
    }
}
