using System;
using System.Collections.Generic;
using System.Text;
using Core.Business;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRentalService: IBaseService<Rental>
    {
        IDataResult<List<RentalDetailDto>> GetDetailRentals();

    }
}
