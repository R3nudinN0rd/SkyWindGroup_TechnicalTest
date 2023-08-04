using SkyWindGroup_TechnicalTest.Entities.Models.CurrencyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyWindGroup_TechnicalTest.Validators
{
    public static class CurrencyValidator
    {
        public static bool ValidateCurrencyModel(CurrencyDTO_POST model)
        {
            var properties = new List<string>
            {
                Type.GetTypeCode(model.CurrencyIndicator.GetType()).ToString()
            };

            return properties.All(prop => prop == "String");
        }
        public static bool ValidateCurrencyModel(CurrencyDTO_PUT model)
        {
            var properties = new List<string>
            {
                Type.GetTypeCode(model.CurrencyIndicator.GetType()).ToString()
            };

            return properties.All(prop => prop == "String");
        }

    }
}
