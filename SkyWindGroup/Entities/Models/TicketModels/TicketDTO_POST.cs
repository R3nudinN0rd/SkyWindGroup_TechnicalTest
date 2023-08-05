using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyWindGroup_TechnicalTest.Entities.Models.TicketModels
{
    public class TicketDTO_POST
    {
        public int Id { get; set; }
        public string NumbersCombination { get; set; }
        public DateTime BoughtDate { get; set; }
        public bool PlayedTicket { get; set; }
        public int TicketValue { get; set; }
        public int DrawHistoryId { get; set; }
        public int CurrencyId { get; set; }
        public int UserId { get; set; }
    }
}
