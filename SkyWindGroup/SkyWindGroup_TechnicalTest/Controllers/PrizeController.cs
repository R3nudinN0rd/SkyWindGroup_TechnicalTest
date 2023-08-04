using Microsoft.AspNetCore.Mvc;
using SkyWindGroup_TechnicalTest.Entities.Models.PrizeModels;
using SkyWindGroup_TechnicalTest.Services.PrizeRepository;
using SkyWindGroup_TechnicalTest.Validators;

namespace SkyWindGroup_TechnicalTest.Controllers
{
    [ApiController]
    [Route("api/prize")]
    public class PrizeController : ControllerBase
    {
        private readonly IPrizeRepository _prizeRepository;
        public PrizeController(IPrizeRepository prizeRepository)
        {
            _prizeRepository = prizeRepository ?? throw new ArgumentNullException(nameof(prizeRepository));
        }

        [HttpGet]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        public ActionResult<IEnumerable<PrizeDTO>> GetAllPrises()
        {
            return Ok(_prizeRepository.GetAllPrisesAsync().GetAwaiter().GetResult());
        }

        [HttpGet("lottery-type/{lotteryTypeId}")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new string[] {"lotteryTypeId"})]
        public ActionResult<IEnumerable<PrizeDTO>> GetPrisesByLotteryId(int lotteryTypeId)
        {
            return Ok(_prizeRepository.GetPrisesByLotteryTypeIdAsync(lotteryTypeId).GetAwaiter().GetResult());
        }

        [HttpGet("{prizeId}")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new string[] {"prizeId"})]
        public ActionResult<PrizeDTO> GetPrizeById(int prizeId)
        {
            var prize = _prizeRepository.GetPrizeByIdAsync(prizeId).GetAwaiter().GetResult();
            return prize==null ? NotFound("Prize not found!") : Ok(prize);              
        }

        [HttpPost]
        public ActionResult AddPrize(PrizeDTO_POST prize) 
        {
            switch (PrizeValidator.ValidatePrizeModel(prize))
            {
                case true:
                    {
                        _prizeRepository.AddPrize(prize);
                        return Ok("Prize added!");
                    }
                case false:
                    {
                        return BadRequest("Prize properties format incorrect!");
                    }
            }
        }

        [HttpPut]
        public ActionResult UpdatePrize(PrizeDTO_PUT prize)
        {
            switch (PrizeValidator.ValidatePrizeModel(prize))
            {
                case true:
                    {
                        _prizeRepository.UpdatePrize(prize);
                        return Ok("Prize updated!");
                    }
                case false:
                    {
                        return BadRequest("Prize properties format incorrect!");
                    }
            }
        }

        [HttpDelete]
        public ActionResult DeletePrize(int prizeId)
        {
            var prize = _prizeRepository.GetPrizeByIdAsync(prizeId).GetAwaiter().GetResult();
            if (prize == null)
            {
                return NotFound("Prize not found!");
            }
            else
            {
                _prizeRepository.DeletePrize(prizeId);
                return Ok("Prize deleted!");   
            }     
            
        }
    }
}
