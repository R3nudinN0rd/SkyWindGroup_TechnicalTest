using Microsoft.AspNetCore.Mvc;
using SkyWindGroup_TechnicalTest.Entities.Models.CurrencyModels;
using SkyWindGroup_TechnicalTest.Services.CurrencyRepository;
using SkyWindGroup_TechnicalTest.Validators;

namespace SkyWindGroup_TechnicalTest.Controllers
{
    [ApiController]
    [Route("api/currency")]
    public class CurrencyController:ControllerBase
    {
        private readonly ICurrencyRepository _currencyRepository;
        public CurrencyController(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository ?? throw new ArgumentNullException(nameof(currencyRepository));
        }

        [HttpGet]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        public ActionResult<IEnumerable<CurrencyDTO>> GetAllCurrencies()
        {
            return Ok(_currencyRepository.GetAllCurrencyAsync().GetAwaiter().GetResult());
        }

        [HttpGet("{currencyId}")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new string[] { "currencyId" })]
        public ActionResult<CurrencyDTO> GetCurrencyById(int currencyId) 
        {
            var currency = _currencyRepository.GetCurrencyByIdAsync(currencyId).GetAwaiter().GetResult();
            return currency == null ? NotFound("Currency not found!") : Ok(currency);
        }

        [HttpPost]
        public ActionResult AddCurrency(CurrencyDTO_POST currency)
        {
            switch (CurrencyValidator.ValidateCurrencyModel(currency))
            {
                case true:
                    {
                        _currencyRepository.AddCurrency(currency);
                        return Ok("Currency added!");
                    }
                case false:
                    {
                        return BadRequest("Currency properties format incorrect!");
                    }
            }
        }

        [HttpPut]
        public ActionResult UpdateCurrency(CurrencyDTO_PUT currency)
        {
            switch (CurrencyValidator.ValidateCurrencyModel(currency))
            {
                case true:
                    {
                        _currencyRepository.UpdateCurrency(currency);
                        return Ok("Currency updated!");
                    }
                case false:
                    {
                        return BadRequest("Currency properties format incorrect!");
                    }
            }
        }

        [HttpDelete]
        public ActionResult DeleteCurrency(int currencyId)
        {
            var currency = _currencyRepository.GetCurrencyByIdAsync(currencyId).GetAwaiter().GetResult();
            if(currency == null)
            {
                return NotFound("Currency not found!");
            }
            else
            {
                _currencyRepository.DeleteCurrency(currencyId);
                return Ok("Currency deleted!");
            }
              
        }
    }
}
