using Microsoft.AspNetCore.Mvc;
using SkyWindGroup_TechnicalTest.Entities.Models.TicketModels;
using SkyWindGroup_TechnicalTest.Repository.TicketRepository;
using SkyWindGroup_TechnicalTest.Validators;
using SkyWindGroup_TechnicalTest.Validators.UserValidator;

namespace SkyWindGroup_TechnicalTest.Controllers
{
    [ApiController]
    [Route("api/ticket")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;
        public TicketController(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository ?? throw new ArgumentNullException(nameof(ticketRepository));
        }

        [HttpGet]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        public ActionResult<IEnumerable<TicketDTO>> GetAllTickets()
        {
            return Ok(_ticketRepository.GetAllTicketsAsync().GetAwaiter().GetResult());
        }

        [HttpGet("user/{userId}")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new string[] {"userId"})]
        public ActionResult<IEnumerable<TicketDTO>> GetTicketsByUserId(int userId)
        {
            return Ok(_ticketRepository.GetTicketsByUserIdAsync(userId).GetAwaiter().GetResult());
        }
        
        [HttpGet("played-tickets")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new string[] {"playedStatus"})]
        public ActionResult<IEnumerable<TicketDTO>> GetTicketsByPlayedStatus(bool playedStatus)
        {
            return Ok(_ticketRepository.GetTicketsByPlayedStatus(playedStatus).GetAwaiter().GetResult());
        }

        [HttpGet("{ticketId}")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new string[] {"ticketId"})]
        public ActionResult<IEnumerable<TicketDTO>> GetTicketById(int ticketId)
        {
            return Ok(_ticketRepository.GetTicketByIdAsync(ticketId).GetAwaiter().GetResult());
        }

        [HttpPost]
        public ActionResult AddTicket(TicketDTO_POST ticket)
        {
            switch(TicketValidator.ValidateTicketModel(ticket))
            {
                case true:
                    {
                        _ticketRepository.AddTicket(ticket);
                        return Ok("Ticket added!");
                    }
                case false:
                    {
                        return BadRequest("Ticket format propeties incorrect!");
                    }
            }
        }

        [HttpPut]
        public ActionResult UpdateTicket(TicketDTO_PUT ticket)
        {
            switch (TicketValidator.ValidateTicketModel(ticket)){
                case true:
                    {
                        _ticketRepository.UpdateTicket(ticket);
                        return Ok("Ticket updated!");
                    }
                case false:
                    {
                        return BadRequest("Ticket properties format incorrect!");
                    }
            }
        }

        [HttpDelete]
        public ActionResult DeleteTicket(int ticketId)
        {
             var ticket = _ticketRepository.GetTicketByIdAsync(ticketId).GetAwaiter().GetResult();
             if (ticket == null)
             {
                return NotFound("Ticket not found!");
             }
             else
             {
                _ticketRepository.DeleteTicket(ticketId);
                return Ok("Ticket deleted!");
             }
                    
        }
    }
}
