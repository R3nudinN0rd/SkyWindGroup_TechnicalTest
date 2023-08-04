using SkyWindGroup_TechnicalTest.Entities.Models.PrizeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyWindGroup_TechnicalTest.Validators
{
    public static class PrizeValidator
    {
        public static bool ValidateId(int id)
        {
            return nameof(id).GetType() == typeof(int);
        }

        public static bool ValidatePrizeModel(PrizeDTO_POST model)
        {
            var properties = new List<string>
            {
                Type.GetTypeCode(model.MatchedNumbers.GetType()).ToString(),
                Type.GetTypeCode(model.LotteryPrizeValue.GetType()).ToString(),
                Type.GetTypeCode(model.CurrencyId.GetType()).ToString(),
                Type.GetTypeCode(model.LotteryTypeId.GetType()).ToString()
            };
            return properties.All(prop => prop == "Int32");
        }

        public static bool ValidatePrizeModel(PrizeDTO_PUT model)
        {
            var properties = new List<string>
            {
                Type.GetTypeCode(model.LotteryPrizeValue.GetType()).ToString(),
                Type.GetTypeCode(model.CurrencyId.GetType()).ToString()
            };

            return properties.All(prop => prop == "Int32");
        }
    }
}
