using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using AdventureWorks.Model.Person;

namespace AdventureWorks.DataAccess.Configurations.Person
{
    internal class Person_AddressConfiguration : EntityTypeConfiguration<Person_Address>
    {
        public Person_AddressConfiguration()
        {
            ToTable("Person.Address");
            HasKey(x => x.AddressId);

            Property(x => x.AddressId).HasColumnName("AddressID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.AddressLine1).HasColumnName("AddressLine1").IsRequired().HasMaxLength(60);
            Property(x => x.AddressLine2).HasColumnName("AddressLine2").IsOptional().HasMaxLength(60);
            Property(x => x.City).HasColumnName("City").IsRequired().HasMaxLength(30);
            Property(x => x.StateProvinceId).HasColumnName("StateProvinceID").IsRequired();
            Property(x => x.PostalCode).HasColumnName("PostalCode").IsRequired().HasMaxLength(15);
            Property(x => x.Rowguid).HasColumnName("rowguid").IsRequired();
            Property(x => x.ModifiedDate).HasColumnName("ModifiedDate").IsRequired();

            // Foreign keys
            HasRequired(a => a.Person_StateProvince).WithMany(b => b.Person_Address).HasForeignKey(c => c.StateProvinceId); // FK_Address_StateProvince_StateProvinceID
        }
    }
}