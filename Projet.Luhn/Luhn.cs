using System.Collections.Specialized;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace Projet.Luhn
{
    public static class Luhn
    {
        public static bool IsValid(string CardNumber)
        {
            int sum = 0;

            // Checks if the inputed Card number only contains numeric characters
            // Also checks if there is 16 numbers for the card number
            if (!IsOnlyNumbers(CardNumber) && CardNumber.Length != 16)
            {
                return false;
            }

            // The Luhn algorithm 
            for (int i = 0; i < CardNumber.Length; i++)
            {
                if (i % 2 != 0)
                {
                    int num = 2 * Int32.Parse(CardNumber[i].ToString());
                    if ( num < 10)
                    {
                        sum += num;
                    } else
                    {
                        sum += ( num - 9 );
                    }
                    
                } else {
                    int num = Int32.Parse(CardNumber[i].ToString());
                    sum += num;
                }                
            }

            return sum % 10 == 0;
        }

        private static bool IsOnlyNumbers(string CardNumber)
        {
            string regex = @"^\d+$";
            return Regex.IsMatch(CardNumber,regex);
        }

        public static string CreateValidCardNumber()
        {
            string baseNum = "497401850223";
            string cardNum;
            var rand = new Random();

            while (true) {
                int[] tabInts = new int[4];

                for (int i = 0; i < 4; i++)
                {
                    tabInts[i] = rand.Next(10);
                }

                if (IsValid(baseNum + string.Join("", tabInts)))
                {
                    return baseNum + string.Join("", tabInts);
                }
            }

        }

        public static string CreateInvalidCardNumber()
        {
            string baseNum = "497401850223";
            string cardNum;
            var rand = new Random();

            while (true)
            {
                int[] tabInts = new int[4];

                for (int i = 0; i < 4; i++)
                {
                    tabInts[i] = rand.Next(10);
                }

                if (!IsValid(baseNum + string.Join("", tabInts)))
                {
                    return baseNum + string.Join("", tabInts);
                }
            }

        }

    }
}
