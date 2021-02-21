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
    public class CustomersController : BaseAPIController<ICustomerService,Customer>
    {
        private ICustomerService _customerService;

        public CustomersController(ICustomerService services, ICustomerService customerService) : base(services)
        {
            _customerService = customerService;
        }

        public IActionResult GetAllCustomerDetail()
        {
            var result = _customerService.GetAllCustomerDetail();
            if (result.Success)
                return Ok(result);

            return BadRequest(result.Message);
        }
    }
}
