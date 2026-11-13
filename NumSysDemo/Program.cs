using System;
using NumSysLib;

namespace NumSysDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== NumSysLib Demo ===");
            Console.WriteLine("Переводы между системами 2, 8, 16.");

            bool running = true;
            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("1 — Универсальный перевод");
                Console.WriteLine("2 — Двоичное → восьмеричное");
                Console.WriteLine("3 — Двоичное → шестнадцатеричное");
                Console.WriteLine("4 — Восьмеричное → двоичное");
                Console.WriteLine("5 — Шестнадцатеричное → двоичное");
                Console.WriteLine("0 — Выход");
                Console.Write("> ");

                string choice = Console.ReadLine()?.Trim();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            Console.Write("Число: ");
                            string v = Console.ReadLine()?.Trim();
                            Console.Write("Из (2/8/16): ");
                            int from = int.Parse(Console.ReadLine()?.Trim() ?? "0");
                            Console.Write("В (2/8/16): ");
                            int to = int.Parse(Console.ReadLine()?.Trim() ?? "0");
                            Console.WriteLine($"Результат: {Adapter.Convert(v, from, to)}");
                            break;

                        case "2":
                            Console.Write("Двоичное: ");
                            Console.WriteLine($"Результат: {Adapter.BinaryToOct(Console.ReadLine()?.Trim())}");
                            break;

                        case "3":
                            Console.Write("Двоичное: ");
                            Console.WriteLine($"Результат: {Adapter.BinaryToHex(Console.ReadLine()?.Trim())}");
                            break;

                        case "4":
                            Console.Write("Восьмеричное: ");
                            Console.WriteLine($"Результат: {Adapter.OctToBinary(Console.ReadLine()?.Trim())}");
                            break;

                        case "5":
                            Console.Write("Шестнадцатеричное: ");
                            Console.WriteLine($"Результат: {Adapter.HexToBinary(Console.ReadLine()?.Trim())}");
                            break;

                        case "0":
                            running = false;
                            break;

                        default:
                            Console.WriteLine("Неверный выбор.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }

            Console.WriteLine("До свидания!");
        }
    }
}