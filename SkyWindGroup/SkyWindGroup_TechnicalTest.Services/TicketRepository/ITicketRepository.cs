using SkyWindGroup_TechnicalTest.Entities;
using SkyWindGroup_TechnicalTest.Entities.Models.TicketModels;

namespace SkyWindGroup_TechnicalTest.Repository.TicketRepository
{
    public interface ITicketRepository
    {
        public Task<IEnumerable<TicketDTO>> GetAllTicketsAsync();
        public Task<IEnumerable<TicketDTO>> GetTicketsByUserIdAsync(int userId);
        public Task<IEnumerable<TicketDTO>> GetTicketsByPlayedStatus(bool playedStatus);
        public Task<TicketDTO> GetTicketByIdAsync(int ticketId);
        public void AddTicket(TicketDTO_POST ticket);
        public void UpdateTicket(TicketDTO_PUT ticket);
        public void DeleteTicket(int ticketID);
    }
}
