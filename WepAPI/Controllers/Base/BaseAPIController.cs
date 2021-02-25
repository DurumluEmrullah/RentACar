using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Business;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WepAPI.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseAPIController<TService, TEntity> : ControllerBase
        where TService : class, IBaseService<TEntity>
        where TEntity : class, IEntity, new()

    {
        private TService _services;

        public BaseAPIController(TService services)
        {
            _services = services;
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _services.GetAll();
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(TEntity entity)
        {
            var result = _services.Add(entity);
            if (result.Success)
                return Ok(result);

            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(TEntity entity)
        {
            var result = _services.Delete(entity);
            if (result.Success)
                return Ok(result);

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(TEntity entity)
        {
            var result = _services.Update(entity);
            if (result.Success)
                return Ok(result);

            return BadRequest(result.Message);
        }
    }
}
