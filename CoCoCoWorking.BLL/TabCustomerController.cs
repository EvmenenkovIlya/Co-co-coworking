using CoCoCoWorking.BLL.Models;
using System.Text.RegularExpressions;

namespace CoCoCoWorking.BLL
{
    public class TabCustomerController
    {
        DataStorage _instance = DataStorage.GetInstance();
        public bool IsNameValid(string name)
        {
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

        public bool IsEmailValid(string email)
        {
            string patternEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, patternEmail);
        }

        public bool IsNumberValid(string number)
        {
            if ((number.StartsWith("+7") || number.StartsWith("8")) && AdjustPhoneNumber(number).Length == 11)
            {
                string patternPhone = @"((8|\+7?)[\- ]?)?(\(?\d{3}\)?[\- ]?)?([\d\- ]{7,10})";
                return Regex.IsMatch(number, patternPhone);
            }

            return false;
        }

        public string AdjustPhoneNumber(string number)
        {
            string result = "";

            if (number.StartsWith("+7"))
            {
                number = number.Replace("+7", "8");
            }

            foreach (char symbol in number)
            {
                if (Char.IsDigit(symbol))
                {

                    result += symbol;
                }
            }
            return result;
        }

        public bool IfClientsNumberAlreadyExists(string number)
        {
            List<CustomerModel> customers = _instance.CustomersToEdit.Where(Customer => Customer.PhoneNumber == number).ToList();

            if (customers.Count() > 0)
            {
                return false;
            }
            return true;
        }
    }
}
