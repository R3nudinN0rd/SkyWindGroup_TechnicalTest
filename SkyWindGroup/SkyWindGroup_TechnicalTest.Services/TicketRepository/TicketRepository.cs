using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SkyWindGroup_TechnicalTest.Context;
using SkyWindGroup_TechnicalTest.Entities;
using SkyWindGroup_TechnicalTest.Entities.Models.TicketModels;

namespace SkyWindGroup_TechnicalTest.Repository.TicketRepository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly SkyWindTTContext _context;
        private readonly IMapper _mapper;
        public TicketRepository(SkyWindTTContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void AddTicket(TicketDTO_POST ticket)
        {
            try
            {
                ticket.BoughtDate = DateTime.Now;
                _context.Tickets.Add(
                    _mapper.Map<Ticket>(ticket)
                    );
                _context.SaveChanges();
            }
            catch(SqlException SqlEx)
            {
                throw SqlEx;
            }
        }

        public void DeleteTicket(int ticketId)
        {
            try
            {
                _context.Tickets.Remove(
                    _context.Tickets.FirstOrDefault(ticket => ticket.Id == ticketId)
                    );
                _context.SaveChanges();
            }
            catch (SqlException SqlEx)
            {
                throw SqlEx;
            }
        }

        public async Task<IEnumerable<TicketDTO>> GetAllTicketsAsync()
        {
            return _mapper.Map<IEnumerable<TicketDTO>>(
                await _context.Tickets.ToListAsync()
                );
        }

        public async Task<TicketDTO> GetTicketByIdAsync(int ticketId)
        {
            return _mapper.Map<TicketDTO>(
                await _context.Tickets.FirstOrDefaultAsync(ticket => ticket.Id == ticketId)
                );
        }

        public async Task<IEnumerable<TicketDTO>> GetTicketsByPlayedStatus(bool playedStatus)
        {
            return _mapper.Map<IEnumerable<TicketDTO>>(
                await _context.Tickets.Where(ticket => ticket.PlayedTicket == playedStatus).ToListAsync()
                );
        }

        public async Task<IEnumerable<TicketDTO>> GetTicketsByUserIdAsync(int userId)
        {
            return _mapper.Map<IEnumerable<TicketDTO>>(
                await _context.Tickets.Where(ticket => ticket.UserId == userId).ToListAsync()
                );
        }

        public void UpdateTicket(TicketDTO_PUT ticket)
        {
            try
            {
                var existingTicket = _context.Tickets.FirstOrDefault(t => t.Id == ticket.Id);
                if (existingTicket != null) { 
                _context.Tickets.Update(_mapper.Map(ticket, existingTicket));
                _context.SaveChanges();
                }
            }
            catch (SqlException SqlEx) 
            {
                throw SqlEx;
            }
        }
    }
}
