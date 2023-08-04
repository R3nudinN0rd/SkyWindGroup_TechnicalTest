using SkyWindGroup_TechnicalTest.Entities.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SkyWindGroup_TechnicalTest.Validators.UserValidator
{
    public static class UserValidator
    {
        public static bool ValidateUserModel(UserDTO_POST model)
        {
            var properties = new List<string>
            {
                Type.GetTypeCode(model.FirstName.GetType()).ToString(),
                Type.GetTypeCode(model.LastName.GetType()).ToString(),
                Type.GetTypeCode(model.IdentificationNumber.GetType()).ToString(),
                Type.GetTypeCode(model.Email.GetType()).ToString(),
                Type.GetTypeCode(model.Password.GetType()).ToString(),
                Type.GetTypeCode(model.PhoneNumber.GetType()).ToString(),
                Type.GetTypeCode(model.Address.GetType()).ToString(),
                Type.GetTypeCode(model.City.GetType()).ToString(),
                Type.GetTypeCode(model.Country.GetType()).ToString()
            };

            return properties.All(prop => prop == "String");
        }

        public static bool ValidateUserModel(UserDTO_PUT model)
        {
            var properties = new List<string>
            {
                Type.GetTypeCode(model.FirstName.GetType()).ToString(),
                Type.GetTypeCode(model.LastName.GetType()).ToString(),
                Type.GetTypeCode(model.Password.GetType()).ToString(),
                Type.GetTypeCode(model.Address.GetType()).ToString(),
                Type.GetTypeCode(model.City.GetType()).ToString(),
                Type.GetTypeCode(model.Country.GetType()).ToString()
            };

            return properties.All(prop => prop == "String");

        }
    }
}
