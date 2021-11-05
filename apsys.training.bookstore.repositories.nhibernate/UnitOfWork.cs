using apsys.training.bookstore.repositores;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace apsys.training.bookstore.repositories.nhibernate
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly ISession _session;
        private ITransaction _transaction;

        public UnitOfWork(ISession session)
        {
            _session = session;
            this._transaction = session.BeginTransaction();
            this.Authors = new AuthorsRepository(this._session);
        }


        public IAuthorsRepository Authors { get; }

        public void Commit()
        {
            if (this._transaction != null && this._transaction.IsActive)
                this._transaction.Commit();
            else
                throw new TransactionException("The actual transaction is not longer active");
        }

        public void Rollback()
        {
            if (this._transaction != null && this._transaction.IsActive)
                this._transaction.Rollback();
            else
                throw new TransactionException("The actual transaction is not longer active");
        }
    }
}
