using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Sys
{
   public class DepartConfiguration:Base_Configuration<DepartModel>
    {
        public override void Configuration(EntityTypeConfiguration<DepartModel> config)
        {
            base.Configuration(config);
            ToTable("SYS_DEPART");
            Property(p => p.Name).HasMaxLength(50).IsRequired().HasColumnName("F_DEPARTNAME");
            Property(p => p.Leader).HasMaxLength(50).HasColumnName("F_LEADER");
            Property(p => p.ParentDepartId).HasColumnName("F_PARENTDEPARTID");
        }
    }
}
