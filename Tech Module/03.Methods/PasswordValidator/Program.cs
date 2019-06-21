using System;


namespace PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            bool IsBetween6and10symbols = CheckLengthOfPassword(password);
            if(IsBetween6and10symbols==false)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            bool ConsistOnlyOfLettersAndDigits = CheckContainsOnlyDigitsAndLetters(password);
            if(ConsistOnlyOfLettersAndDigits==false)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            bool ContainAtLeast2Digits = CheckContainAtLeast2Digits(password);
            if(ContainAtLeast2Digits==false)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
            if(IsBetween6and10symbols && ConsistOnlyOfLettersAndDigits && ContainAtLeast2Digits == true)
            {
                Console.WriteLine("Password is valid");
            }
        }

        private static bool CheckContainAtLeast2Digits(string password)
        {
            int count = 0;
            for(int i=0;i<password.Length;i++)
            {
                char symbol = password[i];
                if(char.IsDigit(symbol))
                {
                    count++;
                }
            }
            // return count>=2 ? true : false;
            if (count >= 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool CheckContainsOnlyDigitsAndLetters(string password)
        {
            for (int i = 0; i < password.Length; i++) 
            {
                char symbol = password[i];
                if(!char.IsLetterOrDigit(symbol))
                {
                    return false;
                }

            }
            return true;
        }

        private static bool CheckLengthOfPassword(string password)
        {
            return password.Length >= 6 && password.Length <= 10 ? true : false;
        }
    }
}
