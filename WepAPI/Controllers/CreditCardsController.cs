using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WepAPI.Controllers.Base;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardsController :BaseAPIController<ICreditCardService,CreditCard>
    {
        private ICreditCardService _creditCardService;

        public CreditCardsController(ICreditCardService creditCardService):base(creditCardService)
        {
            _creditCardService = creditCardService;
        }


        [HttpPost("buy")]
        public IActionResult Buy(BuyDto buyDto)
        {
            var result =_creditCardService.Buy(buyDto);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("refund")]
        public IActionResult Refund(BuyDto buyDto)
        {
            var result = _creditCardService.Refund(buyDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
