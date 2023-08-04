using Microsoft.AspNetCore.Mvc;
using SkyWindGroup_TechnicalTest.Entities.Models.LotteryTypeModels;
using SkyWindGroup_TechnicalTest.Services.LotteryTypeRepository;
using SkyWindGroup_TechnicalTest.Validators;

namespace SkyWindGroup_TechnicalTest.Controllers
{
    [ApiController]
    [Route("api/lotterytype")]
    public class LotteryTypeController : ControllerBase
    {
        private readonly ILotteryTypeRepository _lotteryTypeRepository;
        public LotteryTypeController(ILotteryTypeRepository lotteryTypeRepository)
        {
            _lotteryTypeRepository = lotteryTypeRepository ?? throw new ArgumentNullException(nameof(lotteryTypeRepository));
        }

        [HttpGet]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        public ActionResult<IEnumerable<LotteryTypeDTO>> GetAllLotteryTypes()
        {
            return Ok(_lotteryTypeRepository.GetLotteryTypesAsync().GetAwaiter().GetResult());
        }

        [HttpGet("{lotteryTypeId}")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new string[] {"lotteryTypeId"})]
        public ActionResult<LotteryTypeDTO> GetLotteryTypeById(int lotteryTypeId)
        {
            var lotteryType = _lotteryTypeRepository.GetLotteryTypeByIdAsync(lotteryTypeId).GetAwaiter().GetResult();
            return lotteryType == null ? NotFound("Lottery type not found!") : Ok(lotteryType);  
        }

        [HttpPost]
        public ActionResult AddLotteryType(LotteryTypeDTO_POST lotteryType)
        {
            switch (LotteryTypeValidator.ValidateLotteryTypeModel(lotteryType))
            {
                case true:
                    {
                        _lotteryTypeRepository.AddLotteryType(lotteryType);
                        return Ok("Lottery type added!");
                    }
                case false:
                    {
                        return BadRequest("Lottery type properties format incorrect!");
                    }
            }
        }

        [HttpPut]
        public ActionResult UpdateLotteryType(LotteryTypeDTO_PUT lotteryType)
        {
            switch (LotteryTypeValidator.ValidateLotteryTypeModel(lotteryType))
            {
                case true:
                    {
                        _lotteryTypeRepository.UpdateLotteryType(lotteryType);
                        return Ok("Lottery type updated!");
                    }
                case false:
                    {
                        return BadRequest("Lottery type properties format incorrect!");
                    }
            }
        }

        [HttpDelete]
        public ActionResult DeleteLotteryType(int lotteryTypeId)
        {
            var lotteryType = _lotteryTypeRepository.GetLotteryTypeByIdAsync(lotteryTypeId);
            if (lotteryType == null)
            {
                return NotFound("Lottery type not found!");
            }
            else
            {
                _lotteryTypeRepository.DeleteLotteryType(lotteryTypeId);
                return Ok("Lottery type deleted!");
            }
             
        }

    }
}
