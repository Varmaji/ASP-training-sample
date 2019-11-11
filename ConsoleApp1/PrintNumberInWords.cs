


namespace NumberToVerbal
{
    using System;
    using System.Collections;



    public class Program
    {
        private static void Main()
        {
           
                Console.Write("Enter number to spell: ");
                int number = int.Parse(Console.ReadLine());
                Spell(number);
                Console.WriteLine(Spell(number));

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            
        }



        private static string Spell(int number)
        {
            var baseWords = new Hashtable();
            baseWords.Add(0, "");
            baseWords.Add(1, "one");
            baseWords.Add(2, "two");
            baseWords.Add(3, "three");
            baseWords.Add(4, "four");
            baseWords.Add(5, "five");
            baseWords.Add(6, "six");
            baseWords.Add(7, "seven");
            baseWords.Add(8, "eight");
            baseWords.Add(9, "nine");
            baseWords.Add(10, "ten");
            baseWords.Add(11, "eleven");
            baseWords.Add(12, "twelve");
            baseWords.Add(13, "thirteen");
            baseWords.Add(14, "fourteen");
            baseWords.Add(15, "fifteen");
            baseWords.Add(16, "sixteen");
            baseWords.Add(17, "seventeen");
            baseWords.Add(18, "eighteen");
            baseWords.Add(19, "nineteen");
            baseWords.Add(20, "twenty");
            baseWords.Add(30, "thirty");
            baseWords.Add(40, "forty");
            baseWords.Add(50, "fifty");
            baseWords.Add(60, "sixty");
            baseWords.Add(70, "seventy");
            baseWords.Add(80, "eighty");
            baseWords.Add(90, "ninety");
            baseWords.Add(100, "hundred");
            baseWords.Add(1000, "thousand");
            baseWords.Add(100000, "lakh");
            baseWords.Add(10000000, "crore");

            if (number >= 10000000)
            {
                return Spell(number / 10000000) + " Crore " + Spell(number % 10000000);
            }
            if (number >= 100000)
            {
                return Spell(number / 100000) + " lack " + Spell(number % 100000);
            }
            if (number >= 1000)
            {
                return Spell(number / 1000) + " thousand " + Spell(number % 1000);
            }
            if (number >= 100)
            {
                return Spell(number / 100) + " hundred " + Spell(number % 100);
            }
            if (number >= 21)
            {
                return baseWords[number / 10 * 10] + " " + baseWords[number % 10];
            }
            return baseWords[number].ToString();
        }
    }
}