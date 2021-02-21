using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Business;

namespace Business.Abstract
{
    public interface IColorService: IBaseService<Color>
    {
        IDataResult<Color> GetById(int id);
   
    }
}
