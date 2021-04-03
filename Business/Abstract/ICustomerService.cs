using System;
using System.Collections.Generic;
using System.Text;
using Core.Business;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICustomerService: IBaseService<Customer>
    {

        IDataResult<List<CustomerDetailDto>> GetAllCustomerDetail();
        IDataResult<Customer> GetCustomerById(int id);
    }
}
