using System;
using System.Collections.Generic;
using System.Text;

namespace Study.LabWork2.Feature.Task1.SubTask1
{
    internal class PrimeChecker
    {
        /// <summary>
        /// Проверяет, является ли число простым.
        /// </summary>
        /// <param name="number">Проверяемое число.</param>
        /// <returns>true, если число простое; иначе false.</returns>
        public static bool IsPrime(int number)
        {
            // Числа меньше 2 не являются простыми
            if (number < 2)
                return false;

            // Число 2 — единственное чётное простое число
            if (number == 2)
                return true;

            // Все остальные чётные числа не являются простыми
            if (number % 2 == 0)
                return false;

            // Проверяем делители от 3 до квадратного корня из числа
            int limit = (int)Math.Sqrt(number);
            for (int divisor = 3; divisor <= limit; divisor += 2)
            {
                // Если число делится без остатка — оно не простое
                if (number % divisor == 0)
                    return false;
            }

            // Если делителей не найдено — число простое
            return true;
        }
    }
}
