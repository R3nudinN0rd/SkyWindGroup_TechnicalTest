using SkyWindGroup_TechnicalTest.Entities;
using SkyWindGroup_TechnicalTest.Entities.Models.LotteryTypeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyWindGroup_TechnicalTest.Validators
{
    public class LotteryTypeValidator
    {
        public static bool ValidateLotteryTypeModel(LotteryTypeDTO_POST model)
        {
            var stringProperties = new List<string>
            {
                Type.GetTypeCode(model.Title.GetType()).ToString(),
                Type.GetTypeCode(model.Description.GetType()).ToString()
            };
            var intProperties = new List<string>
            {
                Type.GetTypeCode(model.ExtractedNumbers.GetType()).ToString(),
                Type.GetTypeCode(model.MinimumValue.GetType()).ToString(),
                Type.GetTypeCode(model.MaximumValue.GetType()).ToString()
            };

            return stringProperties.All(prop => prop == "String") &&
                   intProperties.All(prop => prop == "Int32");
        }

        public static bool ValidateLotteryTypeModel(LotteryTypeDTO_PUT model)
        {
            var properties = new List<string>
            {
                Type.GetTypeCode(model.Title.GetType()).ToString(),
                Type.GetTypeCode(model.Description.GetType()).ToString()
            };

            return properties.All(prop => prop == "String");
        }

    }
}
