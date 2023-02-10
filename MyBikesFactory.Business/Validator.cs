using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MyBikesFactory.Business
{
    public static class Validator
    {
        public static bool ValidateSerialNumber(string inputToCheck)
        {
            return int.TryParse(inputToCheck, out _);
        }

        public static bool ValidateUniqueSerialNumber(string inputToCheck, List<Bike> listOfBikes)
        {
            int serialnumber = Convert.ToInt32(inputToCheck);
            foreach (var bike in listOfBikes)
            {
                if (bike.SerialNumber == serialnumber)
                    return false;
            }
            return true;

          
        }

        public static bool ValidateModel(string inputToCheck)
        {
            return Regex.IsMatch(inputToCheck, @"\w{5}$");
        }

        public static bool ValidateManufacturingYear(string inputToCheck)
        {
            
            return Regex.IsMatch(inputToCheck, @"^[0-9]{4}$");


        }

        


    }
}
