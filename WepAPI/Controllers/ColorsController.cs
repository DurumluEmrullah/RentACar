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
    public class ColorsController : BaseAPIController<IColorService,Color>
    {
        private IColorService _colorService;

        public ColorsController(IColorService colorService):base(colorService)
        {
            _colorService = colorService;
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _colorService.GetById(id);
            if (result.Success)
                return Ok(result);

            return BadRequest(result.Message);
        }
    }
}
