using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        IResult Update(User user);
        IDataResult<User> GetUserById(int id);
        IDataResult<User> GetUserDetailByMail(string email);
        User GetByMail(string email);




    }
}
