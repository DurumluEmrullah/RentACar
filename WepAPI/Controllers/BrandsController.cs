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
    public class BrandsController : BaseAPIController<IBrandService,Brand>
    {
        private IBrandService _brandService;

        public BrandsController(IBrandService brandService):base(brandService)
        {
            _brandService = brandService;
        }


        [HttpGet("getbyid")]
        IActionResult GetById(int id)
        {
            var result = _brandService.GetById(id);
            if (result.Success)
                return Ok(result);

            return BadRequest(result.Message);
        }



    }
}
