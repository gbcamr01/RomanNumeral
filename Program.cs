using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RomanNumeral
{
    class Program
    {
        static void Main(string[] args)
        {
            string value = null;
            do
            {
                Console.Write("Enter a integer value (0 will quit!) : ");
                value = Run(Console.ReadLine());

            }
            while (value != string.Empty);
        }

        public static Dictionary<int, string> numeral = new Dictionary<int, string> {
                {1,"I" },
                {2,"II" },
                {3,"III" },
                {4, "IV" },
                {5, "V" },
                {6, "VI" },
                {7, "VII" },
                {8, "VIII" },
                {9, "IX" },
                {10, "X" },
                {40, "XL" },
                {50, "L" },
                {90, "XC" },
                {100, "C" },
                {400, "XC" },
                {500, "D" },
                {900, "CM" },
                {1000, "M" }
        };

        public static string Run(string n)
        {
            var value = 0;
            if (Int32.TryParse(n, out value))
            {
                if (value == 0) return string.Empty;
                Console.WriteLine($"{value} {Run(value)}");
            }
            else
            {
                Console.WriteLine($"Not is not a valid integer!!! Try again!");
            }
             return null;
        }

        public static string Run(int n)
        {
            /*
            * Some work here; return type and arguments should be according to the problem's requirements
            */
            string n_in_roman_alphabet = "";
            StringBuilder sb = new StringBuilder();

            //constraint
            if (n < 1 || n > 10000) { return string.Empty; }

            //edge cases
            if (numeral.ContainsKey(n)) {return numeral[n]; }

            foreach(var multiples in numeral.Keys.OrderByDescending(x=>x))
            {
                if (n > multiples)
                {
                    int remainder;
                    int value = Math.DivRem(n, multiples, out remainder);

                    var repeatedString = string.Concat(Enumerable.Repeat(numeral[multiples], value));
                    sb.Append(repeatedString);
                    n_in_roman_alphabet = sb.ToString();

                    sb.Append(Run(remainder));

                    break;
                }

            }

            n_in_roman_alphabet = sb.ToString();

            return n_in_roman_alphabet;
        }

    }

}
