using System;

namespace SpellNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string isNegative = "";
            try
            {
                Console.WriteLine("Enter a Number to convert to currency");
                string number = Console.ReadLine();
                number = Convert.ToDouble(number).ToString();

                if (number.Contains("-"))
                {
                    isNegative = "Minus ";
                    number = number.Substring(1, number.Length - 1);
                }
                if (number == "0")
                {
                    Console.WriteLine("The number in currency fomat is \nZero Only");
                }
                else
                {
                    Console.WriteLine("The number in currency fomat is \n{0}", isNegative + Spell.ConvertToWords(number));
                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
