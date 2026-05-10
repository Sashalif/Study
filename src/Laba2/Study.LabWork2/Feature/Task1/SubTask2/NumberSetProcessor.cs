using System.Diagnostics;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask2;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask2.DtoModels;

namespace Study.LabWork2.Feature.Task1.SubTask2;

/// <summary>
/// Определяет реализацию для процессора наборов чисел
/// </summary>
public sealed class NumberSetProcessor : INumberSetProcessor
{
    // Наборы данных для обработки
    private readonly List<int[]> _dataSets;

    // Максимальное количество одновременно работающих потоков
    private readonly int _maxConcurrentThreads;

    // Семафор для ограничения количества одновременно работающих потоков
    private readonly Semaphore _semaphore;

    // Объект для блокировки (Monitor через lock) при добавлении в список результатов
    private readonly object _lockObject = new object();

    // Мьютекс для синхронизации доступа к общей сумме
    private readonly Mutex _mutex = new Mutex(false);

    // Общий список результатов
    private readonly List<ResultEntryDto> _results = new List<ResultEntryDto>();

    // Общая сумма всех наборов
    private int _totalSum = 0;

    // Время выполнения
    private TimeSpan _executionTime;

    // Флаг завершения обработки
    private bool _isProcessed = false;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="dataSets">Список наборов чисел для обработки.</param>
    /// <param name="maxConcurrentThreads">Максимальное количество одновременно работающих потоков.</param>
    public NumberSetProcessor(List<int[]> dataSets, int maxConcurrentThreads)
    {
        _dataSets = dataSets ?? throw new ArgumentNullException(nameof(dataSets));
        _maxConcurrentThreads = maxConcurrentThreads;

        // Создаём семафор с заданным количеством мест
        _semaphore = new Semaphore(maxConcurrentThreads, maxConcurrentThreads);
    }

    /// <summary>
    /// Запускает процесс многопоточной обработки наборов чисел.
    /// </summary>
    public void Process()
    {
        // Сбрасываем флаг
        _isProcessed = false;

        // Засекаем время
        Stopwatch stopwatch = Stopwatch.StartNew();

        // Количество наборов
        int setCount = _dataSets.Count;

        // Создаём массив потоков
        Thread[] threads = new Thread[setCount];

        // Запускаем поток для каждого набора
        for (int i = 0; i < setCount; i++)
        {
            // Захватываем переменные в локальные копии для замыкания
            int setNumber = i + 1;            // Номер набора (с 1)
            int[] numbers = _dataSets[i];     // Числа набора

            // Создаём поток
            threads[i] = new Thread(() => ProcessSet(setNumber, numbers));
            threads[i].Name = $"SetProcessor-{setNumber}";
            threads[i].Start();
        }

        // Ожидаем завершения всех потоков
        foreach (Thread thread in threads)
        {
            thread.Join();
        }

        // Останавливаем таймер
        stopwatch.Stop();
        _executionTime = stopwatch.Elapsed;

        // Освобождаем ресурсы
        _semaphore.Dispose();
        _mutex.Dispose();

        // Устанавливаем флаг завершения
        _isProcessed = true;
    }

    /// <summary>
    /// Возвращает результат обработки.
    /// </summary>
    /// <returns>DTO с результатами обработки всех наборов.</returns>
    /// <exception cref="InvalidOperationException">Если обработка ещё не запущена.</exception>
    public ProcessingResultDto GetResult()
    {
        if (!_isProcessed)
        {
            throw new InvalidOperationException(
                "Обработка ещё не завершена. Сначала вызовите Process().");
        }

        return new ProcessingResultDto
        {
            Results = new List<ResultEntryDto>(_results),
            TotalSum = _totalSum,
            ExecutionTime = _executionTime,
            ProcessedSetsCount = _results.Count
        };
    }

    /// <summary>
    /// Обрабатывает один набор чисел в отдельном потоке.
    /// Вычисляет сумму и сохраняет результат.
    /// </summary>
    /// <param name="setNumber">Номер набора (для вывода).</param>
    /// <param name="numbers">Массив чисел для суммирования.</param>
    private void ProcessSet(int setNumber, int[] numbers)
    {
        // 1. Ожидаем разрешения от семафора (место в пуле потоков)
        Console.WriteLine($"Набор {setNumber}: ожидает разрешения на выполнение...");
        _semaphore.WaitOne();

        try
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"Набор {setNumber}: начал подсчёт в потоке {threadId}");

            // 2. Вычисляем сумму набора 
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }

            // 3. Создаём запись результата
            ResultEntryDto entry = new ResultEntryDto
            {
                SetNumber = setNumber,
                Sum = sum,
                ThreadId = threadId
            };

            // 4. Добавляем результат в общий список через Monitor (lock)
            lock (_lockObject)
            {
                _results.Add(entry);
                Console.WriteLine($"Набор {setNumber}: результат добавлен в лог (сумма = {sum})");
            }

            // 5. Обновляем общую сумму через Mutex
            _mutex.WaitOne();
            try
            {
                _totalSum += sum;
                Console.WriteLine($"Набор {setNumber}: общий итог обновлён (текущий итог: {_totalSum})");
            }
            finally
            {
                _mutex.ReleaseMutex();
            }

            Console.WriteLine($"Набор {setNumber}: завершил подсчёт");
        }
        finally
        {
            // 6. Освобождаем место в семафоре
            _semaphore.Release();
            Console.WriteLine($"Набор {setNumber}: освободил место в пуле потоков");
        }
    }
}
