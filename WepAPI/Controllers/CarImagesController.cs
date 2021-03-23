using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WepAPI.Controllers.Base;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : BaseAPIController<ICarImageService,CarImage>
    {
        private ICarImageService _carImageService;
        public CarImagesController(ICarImageService carImageService) : base(carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet("getbycarid")]
        public IActionResult GetByCarId(int id)
        {
            var result = _carImageService.GetCarImage(id);
            if (result.Success)
            {
                if (result.Data.Count < 1)
                {
                    result.Data.Add(new CarImage(){Id=1,ImagePath = "21bdbda5-9024-44d2-84be-dcbf07bb0718.jpg" });
                }

                return Ok(result);
            }
                

            return BadRequest(result.Message);

        }
    }
}
