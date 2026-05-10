using System;
using System.Collections.Generic;
using System.Text;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1.DtoModels;

namespace Study.LabWork2.Feature.Task1.SubTask1
{
    internal class TaskRun1_1
    {
        /// <summary>
        /// Запускает все три версии подсчёта простых чисел.
        /// </summary>
        public static void Run()
        {
            // Параметры
            const int start = 1;
            const int end = 10000;
            const int threadCount = 4;

            Console.WriteLine($"=== Подсчёт простых чисел от {start} до {end} ===\n");

            // Создаём все сервисы
            IPrimeCounter[] services =
            {
            new MonitorService(),
            new MutexService(),
            new SemaphoreService()
        };

            // Запускаем каждый сервис и выводим результат
            foreach (var service in services)
            {
                RunService(service, start, end, threadCount);
            }

            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        /// <summary>
        /// Запускает один сервис и выводит его результат.
        /// </summary>
        private static void RunService(IPrimeCounter service, int start, int end, int threadCount)
        {
            Console.WriteLine($">>> Запуск версии: {service.GetVersionName()} <<<\n");

            PrimeCountResultDto result = service.CountPrimes(start, end, threadCount);

            Console.WriteLine($"\n>>> Краткий итог: {result.ToShortString()}");
            Console.WriteLine("\n\n");
        }
    }
}
