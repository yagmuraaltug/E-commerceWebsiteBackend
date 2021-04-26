using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
   public interface IUserDal:IEntityRepository<User>
    {
        List<string> GetClaims(Expression<Func<User, bool>> filter = null);
        List<OperationClaim> GetClaims(User user);


    }
}
