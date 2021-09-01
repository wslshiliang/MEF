using Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Sys
{
   public class DictionaryConfiguration : Base_Configuration<DictionaryModel>
    {
		public override void Configuration(EntityTypeConfiguration<DictionaryModel> config)
		{
			base.Configuration(config);
			config.ToTable("SYS_DICTIONARY");
			config.Property((DictionaryModel p) => p.EngName).HasColumnName("F_ENGNAME").HasMaxLength(new int?(100));
			config.Property((DictionaryModel p) => p.Name).HasColumnName("F_NAME").HasMaxLength(new int?(50));
			config.Property((DictionaryModel p) => p.NamePy).HasColumnName("F_NAMEPY").HasMaxLength(new int?(32));
			config.Property((DictionaryModel p) => p.SysType).HasColumnName("F_SYSTYPE").HasMaxLength(new int?(32));
			config.Property<int>((DictionaryModel p) => p.LoaDlev).HasColumnName("F_LOADLEV");
			config.Property((DictionaryModel p) => p.SecType).HasColumnName("F_SECTYPE").IsRequired().HasMaxLength(new int?(100));
			config.Property((DictionaryModel p) => p.SecName).HasColumnName("F_SECNAME").IsRequired().HasMaxLength(new int?(100));
			config.Property((DictionaryModel p) => p.CategoryName).HasColumnName("F_CATEGORYNAME").IsRequired().HasMaxLength(new int?(100));
			config.Property((DictionaryModel p) => p.CategoryCode).HasColumnName("F_CATEGORYCODE").IsRequired().HasMaxLength(new int?(100));
			config.Property<int>((DictionaryModel p) => p.Value).HasColumnName("F_VALUE");
			config.Property<int>((DictionaryModel p) => p.LoadIdx).HasColumnName("F_LOADIDX");
			config.Property<E_ValueType>((DictionaryModel p) => p.ValueType).HasColumnName("F_VALUETYPE");
			config.Property((DictionaryModel t) => t.Code).HasMaxLength(new int?(500)).HasColumnName("F_CODE").IsRequired().HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute()));
		}
	}
}
