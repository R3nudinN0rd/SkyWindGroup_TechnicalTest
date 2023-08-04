using Microsoft.AspNetCore.Mvc;
using SkyWindGroup_TechnicalTest.Entities.Models.DrawHistoryModels;
using SkyWindGroup_TechnicalTest.Services.DrawHistoryRepository;
using SkyWindGroup_TechnicalTest.Validators;

namespace SkyWindGroup_TechnicalTest.Controllers
{
    [ApiController]
    [Route("api/drawhistory")]
    public class DrawHistoryController : ControllerBase
    {
        private readonly IDrawHistoryRepository _drawHistoryRepostory;
        public DrawHistoryController(IDrawHistoryRepository drawHistoryRepository)
        {
            _drawHistoryRepostory = drawHistoryRepository ?? throw new ArgumentNullException(nameof(drawHistoryRepository));
        }

        [HttpGet]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        public ActionResult<IEnumerable<DrawHistoryDTO>> GetAllDrawsHistory()
        {
            return Ok(_drawHistoryRepostory.GetAllDrawHistoryAsync().GetAwaiter().GetResult());
        }

        [HttpGet("lottery-type/{lotteryTypeId}")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new string[] {"lotteryTypeId"})]
        public ActionResult<IEnumerable<DrawHistoryDTO>> GetDrawsHistoryByLotteryTypeId(int lotteryTypeId)
        {
            return Ok(_drawHistoryRepostory.GetDrawHistoryByLotteryTypeIdAsync(lotteryTypeId).GetAwaiter().GetResult());
                 
        }

        [HttpGet("date-interval")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new string[] {"date1", "date2"})]
        public ActionResult<IEnumerable<DrawHistoryDTO>> GetDrawsHistoryFromDateInterval(DateTime date1, DateTime date2)
        {
            switch(DrawHistoryValidator.ValidateDateInterval(date1, date2))
            {
                case true:
                    {
                        return Ok(_drawHistoryRepostory.GetDrawHistoryByDrawDateIntervalAsync(date1, date2).GetAwaiter().GetResult());
                    }
                case false:
                    {
                        return BadRequest("Date interval format incorrect!");
                    }
            }
        }

        [HttpGet("{drawHistoryId}")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new string[] {"drawHistoryId"})]
        public ActionResult<DrawHistoryDTO> GetDrawHistoryById(int drawHistoryId)
        {
            var drawHistory = _drawHistoryRepostory.GetDrawHistoryByIdAsync(drawHistoryId).GetAwaiter().GetResult();
            return drawHistory == null ? NotFound("Draw history not found!") : Ok(drawHistory);
        }

        [HttpPost]
        public ActionResult AddDrawHistory(DrawHistoryDTO_POST drawHistory)
        {
            switch (DrawHistoryValidator.ValidateDrawHistoryModel(drawHistory))
            {
                case true:
                    {
                        _drawHistoryRepostory.AddDrawHistory(drawHistory);
                        return Ok("Draw history added!");
                    }
                case false:
                    {
                        return BadRequest("Draw history properties format incorrect!");
                    }
            }
        }

        [HttpPut]
        public ActionResult UpdateDrawHistory(DrawHistoryDTO_PUT drawHistory)
        {
            switch (DrawHistoryValidator.ValidateDrawHistoryModel(drawHistory))
            {
                case true:
                    {
                        _drawHistoryRepostory.UpdateDrawHistory(drawHistory);
                        return Ok("Draw history updated!");
                    }
                case false:
                    {
                        return BadRequest("Draw history properties format incorrect!");
                    }
            }
        }

        [HttpDelete]
        public ActionResult DeleteDrawHistory(int drawHistoryId)
        {
            var drawHistory = _drawHistoryRepostory.GetDrawHistoryByIdAsync(drawHistoryId).GetAwaiter().GetResult();
            if (drawHistory == null)
            {
                return NotFound("Draw history not found!");
            }
            else
            {
                _drawHistoryRepostory.DeleteDrawHistory(drawHistoryId);
                return Ok("Draw history deleted!");
            }
              
        }
    }
}
