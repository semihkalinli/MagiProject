using MagiProject.Data.Abstract;
using MagiProject.Data.Context;
using MagiProject.Domain.Models;
using System;
using System.Linq.Expressions;

namespace MagiProject.Data.Concrete
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private User _user;
        private Expression<Func<User, bool>> _expression;

        public UserRepository(MagiProjectContext context) : base(context)
        {
            _user = new User();
        }

        public MagiProjectContext AutokingOtoEkspertizB2CContext
        {
            get { return context as MagiProjectContext; }
        }

       
    }
}


