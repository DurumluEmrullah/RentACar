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
                return Ok(result);

            return BadRequest(result.Message);

        }
    }
}
