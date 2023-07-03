using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
namespace FizzAndBuzz.Collections
{
    public class FizzBuzzBL:IFizzBuzzBL
    {
        private IReminder _reminder;
        public FizzBuzzBL()
        {
            _reminder = new Reminder();
        }

        public string ArryValues(string value)
        {
            string result = string.Empty;
            int number;
            if (int.TryParse(value, out number))
            {
                if (_reminder.GetReminder(number, 3) == 0 && _reminder.GetReminder(number, 5) == 0)
                    result = FBConstants.FizzBuzz;
                else if (_reminder.GetReminder(number, 3) == 0)
                    result = FBConstants.Fizz;
                else if (_reminder.GetReminder(number, 5) == 0)
                    result = FBConstants.Buzz;
                else
                {
                    result = FBConstants.NotDivisibleByThreeOrFive;
                }
            }
            else
                result = FBConstants.InvalidValue;

            return result;
        }
    }
    public interface IReminder
    {
        public decimal GetReminder(int divisor, int quotient);
    }

    public interface IFizzBuzzBL
    {
        public string ArryValues(string value);
    }

    public class Reminder : IReminder
    {
        public decimal GetReminder(int divisor, int quotient)
        {
            return divisor % quotient;
        }
    }

    public class FBConstants
    {
        public const string InvalidValue = "Invalid entry!! Please enter nubers separated by commas.";
        public const string Message = "Divided {0} by {1}";
        public const string FizzBuzz = "FizzBuzz";
        public const string Fizz = "Fizz";
        public const string Buzz = "Buzz";
        public const string NumberOfChars = "Please enter up to 50 characters";
        public const string NotDivisibleByThreeOrFive = "Entered Value is not divisible by 3 or 5";
    }
}
