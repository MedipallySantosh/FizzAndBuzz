namespace FizzAndBuzz.Collections
{
    public class FizzBuzzBL : IFizzBuzzBL
    {
        private readonly IReminder _reminder;

        /// <summary>
        /// Constructor Injection
        /// </summary>
        /// <param name="Reminder"></param>
        public FizzBuzzBL(IReminder Reminder)
        {
            _reminder = Reminder;
        }

        /// <summary>
        /// Logic of divisible by 3 and 5
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        
        public string ArryValues(string value)
        {
            string result = string.Empty;
            int number;
            if (int.TryParse(value, out number))
            {
                if (_reminder.GetReminder(number, 15) == 0) //divisible by both 3 and 5
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

    /// <summary>
    /// Interface declarations
    /// </summary>
    public interface IReminder
    {
        public decimal GetReminder(int divisor, int quotient);
    }

    public interface IFizzBuzzBL
    {
        public string ArryValues(string value);
    }

    /// <summary>
    /// Class declarations
    /// </summary>
    public class Reminder : IReminder
    {
        public decimal GetReminder(int divisor, int quotient)
        {
            return divisor % quotient;
        }
    }

    /// <summary>
    /// Constant values
    /// </summary>
    public class FBConstants
    {
        public const string InvalidValue = "Invalid entry.";
        public const string Message = "Divided {0} by {1}";
        public const string FizzBuzz = "FizzBuzz";
        public const string Fizz = "Fizz";
        public const string Buzz = "Buzz";
        public const string NumberOfChars = "Please enter up to 50 characters";
        public const string NotDivisibleByThreeOrFive = "Entered Value is not divisible by 3 or 5";
    }
}
