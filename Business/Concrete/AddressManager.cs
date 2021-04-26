using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AddressManager : IAddressService
    {
        IAddressDal _addressDal;

        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }

        public IDataResult<List<Address>> GetAll()
        {
            //İş kodları
            return new SuccessDataResult<List<Address>>(_addressDal.GetAll());
        }

        public IDataResult<Address> GetByUserId(int userId)
        {
            return new SuccessDataResult<Address>(_addressDal.Get(c => c.Id == userId));
        }

        public IDataResult<Address> GetByCityId(int cityId)
        {
            return new SuccessDataResult<Address>(_addressDal.Get(c => c.Id == cityId));
        }
    }
}
