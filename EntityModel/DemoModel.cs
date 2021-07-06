using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModel
{
    [Table("W_DemoClass")]
    public class DemoModel
    {
        [Column("Id")] 
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> Age { get; set; }

        public CountryModel CountryData { get; set; }
        public int CountryId { get; set; }
    }
}
