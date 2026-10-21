using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration_Homework
{

    internal class Student
    {

        private static int nextId = 1;
        private int Age;
        private int Id;
        private string Name;
        private int Grade;
        private double AverageScore;
        private decimal Fee;
        private bool HasScholarship;
        private char ClassLetter;
        private DateTime BirthDate;


        static void Main()
        {


            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== ВЪВЕЖДАНЕ НА ДАННИ ЗА УЧЕНИК ===");
            Console.WriteLine();

            int id = nextId++;
            string name = ReadValue("Име: ", s => s);

            Student student = new Student(id, name);

            student.Age = ReadValue(
                    "Възраст: ", int.Parse);

            student.Grade = ReadValue(
                    "Клас: ", int.Parse);

            student.AverageScore = ReadValue(
                    "Среден успех: ", ParseDouble);

            student.Fee = ReadValue(
                    "Такса (лв.): ", ParseDecimal);

            student.HasScholarship = ReadValue(
                    "Получава ли стипендия? (да/не): ",
                ParseBool);

            student.ClassLetter = ReadValue(
                    "Паралелка: ", ParseChar);

            student.BirthDate = ReadValue(
                    "Дата на раждане (дд.ММ.гггг): ",
                ParseDate);

            Console.WriteLine();
            Console.WriteLine("=== ДАННИ ЗА УЧЕНИК ===");
            Console.WriteLine();

            Console.WriteLine($"Id: {student.Id}");
            Console.WriteLine($"Име: {student.Name}");
            Console.WriteLine($"Възраст: {student.Age}");
            Console.WriteLine($"Клас: {student.Grade}");
            Console.WriteLine(
                $"Среден успех: {student.AverageScore:F2}");
            Console.WriteLine(
                $"Такса: {student.Fee:F2} лв.");
            Console.WriteLine(
                $"Стипендия: {(student.HasScholarship ? "Да" : "Не")}");
            Console.WriteLine($"Паралелка: {student.ClassLetter}");
            Console.WriteLine(
                $"Дата на раждане: {student.BirthDate:dd.MM.yyyy}");

        }


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
