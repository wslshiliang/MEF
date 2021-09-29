using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Sys
{
   public class ModuleConfiguration : Base_Configuration<ModuleModel>
    {
        public override void Configuration(EntityTypeConfiguration<ModuleModel> config)
        {
            base.Configuration(config);
            ToTable("SYS_MODULE");
            Property(p => p.ModuleType).HasColumnName("F_TYPE").IsRequired();
            Property(p => p.Name).HasColumnName("F_NAME").IsRequired().HasMaxLength(50);
            Property(p => p.Url).HasColumnName("F_URL").IsRequired().HasMaxLength(100);
            Property(p => p.Icon).HasColumnName("F_ICON").HasMaxLength(50);
            Property(p => p.ParentId).HasColumnName("F_PARENTID");
            Property(p => p.Idx).HasColumnName("F_IDX").IsRequired().HasMaxLength(10);
            Property(p => p.TargetType).HasColumnName("F_TARGET").HasMaxLength(10);
            Property(p => p.RouteName).HasColumnName("F_ROUTENAME").HasMaxLength(50);
            Property(p => p.RoutePath).HasColumnName("F_ROUTEPATH").HasMaxLength(50);
            Property(p => p.RouteComponent).HasColumnName("F_ROUTECOMPONENT").HasMaxLength(50);
            Property(p => p.RouteCache).HasColumnName("F_ROUTECACHE").IsRequired();
            HasOptional(p => p.Parent).WithMany(p => p.Childs).HasForeignKey(p => p.ParentId).WillCascadeOnDelete(false);
        }
    }
}
