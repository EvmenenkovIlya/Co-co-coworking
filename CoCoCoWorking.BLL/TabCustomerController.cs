using CoCoCoWorking.BLL.Models;
using System.Text.RegularExpressions;

namespace CoCoCoWorking.BLL
{
    public class TabCustomerController
    {
        public bool IsNumberValid(string number)
        {
            //bool IsNumberValid = true;

            if (number.Length != 11)
            {
                return false;
            }

            foreach (char symbol in number)
            {
                if (Char.IsLetter(symbol))
                {
                    //IsNumberValid = false;
                    return false;
                }
            }
            return true;
            //return IsNumberValid;
        }

        public bool IsEmailValid(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        }

        public bool IsNameValid(string name)
        {
            //bool isNameValid = true;

            if (name.Length > 255)
            {
                return false;
            }

            foreach (char symbol in name)
            {
                if (!Char.IsLetter(symbol))
                {
                    return false;
                }
            }
            return true;
        }

        public bool IfNumberExist(List<CustomerModel> customers, string number)
        {
            foreach(CustomerModel customer in customers)
            {
                if (customer.PhoneNumber == number)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
