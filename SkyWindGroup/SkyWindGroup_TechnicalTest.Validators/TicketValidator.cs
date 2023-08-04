using SkyWindGroup_TechnicalTest.Entities.Models.TicketModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyWindGroup_TechnicalTest.Validators
{
    public class TicketValidator
    {
        public static bool ValidateTicketModel(TicketDTO_POST model)
        {
            var stringProperties = new List<string>
            {
                Type.GetTypeCode(model.NumbersCombination.GetType()).ToString()
            };
            var intProperties = new List<string>
            {
                Type.GetTypeCode(model.TicketValue.GetType()).ToString(),
                Type.GetTypeCode(model.DrawHistoryId.GetType()).ToString(),
                Type.GetTypeCode(model.CurrencyId.GetType()).ToString(),
                Type.GetTypeCode(model.UserId.GetType()).ToString()
            };

            return stringProperties.All(prop => prop == "String") &&
                   intProperties.All(prop => prop == "Int32");
        }

        public static bool ValidateTicketModel(TicketDTO_PUT model)
        {
            var intProperties = new List<string>
            {
                Type.GetTypeCode(model.TicketValue.GetType()).ToString(),
                Type.GetTypeCode(model.CurrencyId.GetType()).ToString()
            };
            return intProperties.All(prop => prop == "Int32");
        }

    }
}
