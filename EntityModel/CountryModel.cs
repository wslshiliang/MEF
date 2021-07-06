using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    [Table("W_Country")]
    public class CountryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<DemoModel> DemoClasses { get; set; }
    }
}
