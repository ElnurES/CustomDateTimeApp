using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDateTimeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter current date (format dd.mm.yyyy)");
            string date = Console.ReadLine();

            Console.WriteLine("Please select operation type (+ or -)");
            char symbol = char.Parse(Console.ReadLine());

            Console.WriteLine("Please enter day to add or subtract");
            int day = Convert.ToInt32(Console.ReadLine());

            try
            {
                CustomDateTime customDateTime = new CustomDateTime(date);
                if(symbol =='+')
                {
                    customDateTime.AddDay(day);
                }
                else
                    customDateTime.Subtract(day);

                Console.WriteLine(customDateTime);
            }
            catch(Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            Console.ReadLine();


        }
    }
}
