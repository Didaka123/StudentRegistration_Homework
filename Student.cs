using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration_Homework
{
    
    internal class Student
    {

    

    static T ReadValue<T>(
        string prompt, Func<string, T> parser)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine() ?? "";

                try
                {
                    return parser(input);
                }
                catch (FormatException)
                {
                    Console.WriteLine(
                        "Невалиден формат. Опитайте отново.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine(
                        "Въведената стойност е извън допустимия диапазон.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Грешка: {ex.Message}");
                }
            }
        }

        static double ParseDouble(string input)
        {
            return double.Parse(
                input.Replace(',', '.'),
                CultureInfo.InvariantCulture);
        }

        static decimal ParseDecimal(string input)
        {
            return decimal.Parse(
                input.Replace(',', '.'),
                CultureInfo.InvariantCulture);
        }

        static bool ParseBool(string input)
        {
            if (input.Trim().Equals(
                "да", StringComparison.OrdinalIgnoreCase))
                return true;

            if (input.Trim().Equals(
                "не", StringComparison.OrdinalIgnoreCase))
                return false;

            throw new FormatException(
                "Въведете „да“ или „не“.");
        }

        static char ParseChar(string input)
        {
            input = input.Trim();

            if (input.Length != 1)
            {
                throw new FormatException(
                    "Въведете точно една буква.");
            }

            return input[0];
        }

        static DateTime ParseDate(string input)
        {
            return DateTime.ParseExact(
                input.Trim(),
                "dd.MM.yyyy",
                CultureInfo.InvariantCulture);
        }
    }
}
