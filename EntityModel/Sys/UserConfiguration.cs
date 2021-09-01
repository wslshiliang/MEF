using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Sys
{
   public class UserConfiguration : Base_Configuration<UserModel>
    {
        public override void Configuration(EntityTypeConfiguration<UserModel> config)
        {
            base.Configuration(config);
            ToTable("SYS_USER");
            Property(p => p.UserId).HasColumnName("F_USERID").HasMaxLength(50).IsRequired();
            Property(p => p.UserName).HasColumnName("F_UNAME").HasMaxLength(50).IsRequired();
            Property(p => p.UserPwd).HasColumnName("F_PWD").HasMaxLength(32).IsRequired(); 
            Property(p => p.MPhone).HasColumnName("F_MPHONE").HasMaxLength(32);  
            Property(p => p.Address).HasColumnName("F_ADDR").HasMaxLength(100); 
            Property(p => p.DepartId).HasColumnName("F_DEPART").IsRequired();
            Property(p => p.IsOnLine).HasColumnName("F_ONLINE").IsRequired();
            config.HasRequired(p => p.Depart).WithMany(d => d.Users).HasForeignKey(p => p.DepartId).WillCascadeOnDelete(true);
        }
    }
}
