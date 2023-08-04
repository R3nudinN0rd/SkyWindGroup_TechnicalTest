using SkyWindGroup_TechnicalTest.Entities.Models.DrawHistoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyWindGroup_TechnicalTest.Validators
{
    public class DrawHistoryValidator
    {

        public static bool ValidateDrawHistoryModel(DrawHistoryDTO_POST model)
        {
            var intProperties = new List<string>
            {
                Type.GetTypeCode(model.LotteryTypeId.GetType()).ToString()
            };

            return intProperties.All(prop => prop == "Int32");
        }

        public static bool ValidateDrawHistoryModel(DrawHistoryDTO_PUT model)
        {
            var intProperties = new List<string>
            {
                Type.GetTypeCode(model.LotteryTypeId.GetType()).ToString()
            };

            return intProperties.All(prop => prop == "Int32");
        }

        public static bool ValidateDateInterval(DateTime date1, DateTime date2)
        {
            var properties = new List<string>
            {
                Type.GetTypeCode(date1.GetType()).ToString(),
                Type.GetTypeCode(date2.GetType()).ToString()
            };

            return properties.All(prop => prop == "DateTime") &&
                   date1 < date2;
        }
    }
}
