using MagiProject.Data.Abstract;
using MagiProject.Data.Context;
using System;

namespace MagiProject.Data.Concrete
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly MagiProjectContext _dbContext;

        public EfUnitOfWork(MagiProjectContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentException("dbContext can't use");
        }

        private IUserRepository _userRepository;

        #region CampaignLog
        public IUserRepository UserRepository
        {
            get
            {
                return _userRepository ?? (_userRepository = new UserRepository(_dbContext));
            }
        }

        #endregion

       

        public void SaveChanges()
        {
            try
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        _dbContext.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        var xx = ex;
                        transaction.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
                string exMsj = ex.Message;
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
