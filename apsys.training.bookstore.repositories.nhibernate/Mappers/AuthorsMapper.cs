
using apsys.training.bookstore;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

public class AuthorsMappers : ClassMapping<Author>
{

    public AuthorsMappers()
    {
        Table("Authors");
        Id(x => x.Id, x =>
        {
            x.Generator(Generators.Assigned);
            x.Column("Id");
        });
        Property(x => x.FirstName, x =>
        {
            x.Column("FirstName");
        });
        Property(x => x.LastName, x =>
        {
            x.Column("LastName");
        });
    }
}