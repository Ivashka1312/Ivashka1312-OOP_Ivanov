using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        // Оголошення регулярного виразу для перевірки введеного рядка
        string pattern = @"^(\d{1,9})[+-](\d{1,9})=(\d+)$";
        Regex regex = new Regex(pattern);

        // Запит у користувача ввести рядок для перевірки
        Console.WriteLine("Введiть рядок для перевiрки:");
        string input = Console.ReadLine(); //зчитуєм рядок введений користувачем з клавіатури та зберігає його у змінній input

        // Перевірка введеного рядка на відповідність регулярному виразу
        Match match = regex.Match(input);
        if (match.Success)
        {
            // Витягнення чисел та оператора з рядка
            int number1 = int.Parse(match.Groups[1].Value);
            int number2 = int.Parse(match.Groups[2].Value);
            int expectedResult = int.Parse(match.Groups[3].Value);
            char operation = input[number1.ToString().Length]; 


            // Обчислення результату в залежності від операції
            int result = operation == '+' ? number1 + number2 : number1 - number2;

            // Перевірка результату на відповідність очікуваному
            if (result == expectedResult)
            {
                Console.WriteLine("Вираз вiрний.");
            }
            else
            {
                Console.WriteLine("Вираз невiрний.");
            }
        }
        else
        {
            // Виведення повідомлення, якщо введений рядок не відповідає формату
            Console.WriteLine("Рядок не вiдповiдає формату.");
        }

        Console.ReadKey(); // Очікування натискання клавіші перед виходом з програми
    }
}
