using System;
using System.Collections.Generic;
using System.Text;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask2.DtoModels;

namespace Study.LabWork2.Feature.Task1.SubTask2
{
    internal class TaskRun1_2
    {
        /// <summary>
        /// Запускает задание 1.2: многопоточный подсчёт сумм наборов.
        /// </summary>
        public static void Run()
        {
            Console.WriteLine("=== Задание 1.2: Многопоточный подсчёт сумм наборов ===\n");

            // Загружаем наборы данных
            DataSets dataSets = DataSets.Load();

            Console.WriteLine($"Загружено {dataSets.Sets.Count} наборов по {dataSets.Sets[0].Length} чисел\n");

            // Максимальное количество одновременно работающих потоков
            const int maxConcurrentThreads = 4;

            // Создаём процессор
            NumberSetProcessor processor = new NumberSetProcessor(dataSets.Sets, maxConcurrentThreads);

            // Запускаем обработку
            Console.WriteLine("Начинаем многопоточный подсчёт...\n");
            processor.Process();

            // Получаем результат
            ProcessingResultDto result = processor.GetResult();

            // Выводим результаты
            Console.WriteLine("\n=================================");
            Console.WriteLine("=== РЕЗУЛЬТАТЫ ПОДСЧЁТА ===");
            Console.WriteLine("=================================");

            // a. Сумма каждого набора с указанием потока
            Console.WriteLine("\nСуммы по наборам:");
            Console.WriteLine(new string('-', 45));

            foreach (var entry in result.Results.OrderBy(r => r.SetNumber))
            {
                Console.WriteLine(entry);
            }

            // b. Общий итог
            Console.WriteLine(new string('=', 45));
            Console.WriteLine($"Общий итог по всем наборам: {result.TotalSum}");

            // c. Время выполнения
            Console.WriteLine($"Время выполнения: {result.ExecutionTime.TotalMilliseconds:F2} мс");
            Console.WriteLine($"Обработано наборов: {result.ProcessedSetsCount}");
            Console.WriteLine(new string('=', 45));

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }
}
