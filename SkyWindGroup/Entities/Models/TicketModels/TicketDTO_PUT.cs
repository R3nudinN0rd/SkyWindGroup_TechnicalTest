using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyWindGroup_TechnicalTest.Entities.Models.TicketModels
{
    public class TicketDTO_PUT
    {
        public int Id { get; set; }
        public bool PlayedTicket { get; set; }
        public int TicketValue { get; set; }
        public int CurrencyId { get; set; }
    }
}
