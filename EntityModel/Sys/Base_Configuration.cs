using EntityModel.Sys;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EntityModel
{
    public class Base_Configuration<T> : EntityTypeConfiguration<T> where T : BaseModel
    {
        public Base_Configuration()
        {
            Configuration(this);
        }
        public virtual void Configuration(EntityTypeConfiguration<T> config)
        {
            config.HasKey(t => t.Id)
                .Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("F_ID");

            config.Property(t => t.IsUsed)
                .IsRequired()
                .HasColumnName("F_ISUSED");
            config.Property(t => t.CrtUser)
                .IsRequired()
                .HasColumnName("F_CRTUSER")
                .HasMaxLength(30);
            config.Property(t => t.CrtTime)
                .IsRequired()
                .HasColumnName("F_CRTTIME");
            config.Property(t => t.EdtUser)
                .HasColumnName("F_EDTUSER")
                .HasMaxLength(30);
            config.Property(t => t.EdtTime)
                .HasColumnName("F_EDTTIME");
            config.Property(t => t.Remark)
                .HasColumnName("F_REMARK")
                .HasMaxLength(2000);
        }
    }
}
