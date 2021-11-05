using apsys.repository.nhibernate.core;
using apsys.training.bookstore.repositores;
using NHibernate;
using System;

namespace apsys.training.bookstore.repositories.nhibernate
{
    public class AuthorsRepository : Repository<Author>, IAuthorsRepository
    {
        public AuthorsRepository(ISession session)
            :base(session)
        {

        }
    }
}
