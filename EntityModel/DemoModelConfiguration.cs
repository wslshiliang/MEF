using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
   public class DemoModelConfiguration : Base_Configuration<DemoModel>
    {
        public DemoModelConfiguration() 
        { 
            ToTable("W_DemoClass")                  
            .HasKey(q => q.Id) 
            .Property(q => q.CountryId).IsRequired(); 
        }
    }
}

