using System;

namespace hw3
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(WhatDay(60, 2023));
            }
            catch (ArgumentOutOfRangeException e) {
                Console.WriteLine(e.Message);
            }
        }

        static string WhatDay(int day, int year)
        {
            bool isLeapYear = year % 4 == 0;
            if (day < 1 || day > (isLeapYear ? 366 : 365))
            {
                throw new ArgumentOutOfRangeException("day out of range");
            }
            int[] daysInMonths = new int[] { 31, isLeapYear ? 29 : 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            string[] months = new string[] { "jan", "feb", "mar", "apr", "may", "jun", "jul", "aug", "sep", "oct", "nov", "dec" };
            for (int i = 0; i < 12; i++)
            {
                if (day <= daysInMonths[i])
                {
                    return months[i] + " " + day.ToString();
                }
                else
                {
                    day -= daysInMonths[i];
                }
            }
            throw new Exception();
        }
    }
}
