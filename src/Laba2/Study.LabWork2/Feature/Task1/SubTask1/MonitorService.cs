using System.Diagnostics;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1.DtoModels;
using static Study.LabWork2.Feature.Task1.SubTask1.PrimeChecker;

namespace Study.LabWork2.Feature.Task1.SubTask1;

/// <summary>
/// Версия 1. Использует Monitor (lock) для синхронизации.
/// </summary>
public sealed class MonitorService : IPrimeCounter
{
    /// <summary>
    /// Возвращает название версии счетчика.
    /// </summary>
    public string GetVersionName()
    {
        return "Monitor (lock)";
    }

    /// <summary>
    /// Запускает подсчет простых чисел в заданном диапазоне.
    /// </summary>
    /// <param name="start">Начало диапазона (включительно).</param>
    /// <param name="end">Конец диапазона (включительно).</param>
    /// <param name="threadCount">Количество потоков для подсчета.</param>
    /// <returns>Результат подсчета.</returns>
    public PrimeCountResultDto CountPrimes(int start, int end, int threadCount)
    {
        int primeCount = 0;
        List<int> foundPrimes = new List<int>();
        object lockObject = new object();

        Thread[] threads = new Thread[threadCount];
        Stopwatch stopwatch = Stopwatch.StartNew();

        int totalNumbers = end - start + 1;
        int rangeSize = totalNumbers / threadCount;

        // Флаг для включения/отключения вывода каждого проверяемого числа
        // Установить false, чтобы видеть только найденные простые числа
        bool showEveryCheck = false;

        for (int i = 0; i < threadCount; i++)
        {
            int threadStart = start + i * rangeSize;
            int threadEnd = (i == threadCount - 1) ? end : start + (i + 1) * rangeSize - 1;

            if (i == 0)
                threadStart = start;

            int threadNumber = i + 1;
            int tStart = threadStart;
            int tEnd = threadEnd;

            threads[i] = new Thread(() =>
            {
                ProcessRange(threadNumber, tStart, tEnd, lockObject, ref primeCount, foundPrimes, showEveryCheck);
            });

            threads[i].Name = $"Thread-{threadNumber}";
            threads[i].Start();
        }

        foreach (Thread thread in threads)
        {
            thread.Join();
        }

        stopwatch.Stop();

        // Выводим информацию о диапазонах потоков
        for (int i = 0; i < threadCount; i++)
        {
            int threadStart = start + i * rangeSize;
            int threadEnd = (i == threadCount - 1) ? end : start + (i + 1) * rangeSize - 1;
            if (i == 0) threadStart = start;
            Console.WriteLine($"Поток {i + 1}: диапазон [{threadStart}, {threadEnd}]");
        }

        Console.WriteLine($"\n=================================");
        Console.WriteLine($"Версия: {GetVersionName()}");
        Console.WriteLine($"Диапазон: [{start}, {end}]");
        Console.WriteLine($"Количество потоков: {threadCount}");
        Console.WriteLine($"Общее количество простых чисел: {primeCount}");
        Console.WriteLine($"Время выполнения: {stopwatch.ElapsedMilliseconds} мс");
        Console.WriteLine($"=================================");

        return new PrimeCountResultDto
        {
            PrimeCount = primeCount,
            ExecutionTime = stopwatch.Elapsed,
            ThreadCount = threadCount,
            SynchronizationType = GetVersionName(),
            FoundPrimes = foundPrimes
        };
    }

    /// <summary>
    /// Обрабатывает заданный диапазон чисел в отдельном потоке.
    /// </summary>
    private void ProcessRange(int threadNumber, int start, int end, object lockObject, ref int primeCount, List<int> foundPrimes, bool showEveryCheck)
    {
        for (int number = start; number <= end; number++)
        {
            bool isPrime = PrimeChecker.IsPrime(number);

            // Выводим каждое проверяемое число только если флаг включен
            if (showEveryCheck)
            {
                Console.WriteLine($"Поток {threadNumber}: проверяю число {number}");
            }

            if (isPrime)
            {
                lock (lockObject)
                {
                    primeCount++;
                    foundPrimes.Add(number);
                    int currentCount = primeCount;

                    // Сообщение о найденном простом числе
                    Console.WriteLine($"Поток {threadNumber}: НАШЁЛ простое число {number}. Всего найдено: {currentCount}");
                }
            }

            // Задержка для наглядности
            if (showEveryCheck)
            {
                Thread.Sleep(1);
            }
        }
    }
}
