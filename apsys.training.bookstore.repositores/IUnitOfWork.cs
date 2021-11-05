using System;
using System.Collections.Generic;
using System.Text;

namespace apsys.training.bookstore.repositores
{
    public interface IUnitOfWork
    {
        IAuthorsRepository Authors { get; }
        void Commit();
        void Rollback();

    }
}
