using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
   public class CountryConfiguration : EntityTypeConfiguration<CountryModel>
    {
        public CountryConfiguration() 
        { 
            ToTable("W_Country")                                                  //映射表 
                .HasKey(q => q.Id)                                       //指定主键 
                .HasMany(q => q.DemoClasses).WithRequired(q => q.CountryData).HasForeignKey(q => q.CountryId);        //配置一对多关系 
        }
    }
}
