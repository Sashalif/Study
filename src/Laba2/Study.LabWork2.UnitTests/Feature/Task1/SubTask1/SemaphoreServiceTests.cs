using Study.LabWork2.Abstractions.Feature.Task1.SubTask1;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1.DtoModels;
using Study.LabWork2.Feature.Task1.SubTask1;

namespace Study.LabWork2.UnitTests.Feature.Task1.SubTask1;

/// <summary>
/// Тесты для версии с Semaphore.
/// </summary>
[TestFixture]
public sealed class SemaphoreServiceTests
{
    private SemaphoreService _service;

    /// <summary>
    /// Инициализация перед каждым тестом.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        _service = new SemaphoreService();
    }

    /// <summary>
    /// Проверяет, что GetVersionName возвращает правильное название.
    /// </summary>
    [Test]
    public void GetVersionName_ShouldReturnSemaphore()
    {
        // Act
        string versionName = _service.GetVersionName();

        // Assert
        Assert.That(versionName, Is.EqualTo("Semaphore"));
    }

    /// <summary>
    /// Проверяет, что сервис реализует интерфейс IPrimeCounter.
    /// </summary>
    [Test]
    public void Service_ShouldImplementIPrimeCounter()
    {
        // Assert
        Assert.That(_service, Is.InstanceOf<IPrimeCounter>());
    }

    /// <summary>
    /// Проверяет корректность подсчёта в небольшом диапазоне с одним потоком.
    /// Ожидаемые простые числа от 1 до 10: 2, 3, 5, 7 (всего 4).
    /// </summary>
    [Test]
    public void CountPrimes_SmallRangeSingleThread_ShouldReturnCorrectResult()
    {
        // Arrange
        int start = 1;
        int end = 10;
        int threadCount = 1;

        // Act
        PrimeCountResultDto result = _service.CountPrimes(start, end, threadCount);

        // Assert
        Assert.That(result.PrimeCount, Is.EqualTo(4));
        Assert.That(result.ThreadCount, Is.EqualTo(1));
        Assert.That(result.SynchronizationType, Is.EqualTo("Semaphore"));
        Assert.That(result.ExecutionTime.TotalMilliseconds, Is.GreaterThan(0));
        Assert.That(result.FoundPrimes, Is.Not.Null);
        Assert.That(result.FoundPrimes, Is.EquivalentTo(new[] { 2, 3, 5, 7 }));
    }

    /// <summary>
    /// Проверяет корректность подсчёта с несколькими потоками.
    /// </summary>
    [Test]
    public void CountPrimes_MultipleThreads_ShouldReturnCorrectResult()
    {
        // Arrange
        int start = 1;
        int end = 100;
        int threadCount = 4;

        // Ожидаемые простые числа от 1 до 100
        int[] expectedPrimes = new[]
        {
                2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47,
                53, 59, 61, 67, 71, 73, 79, 83, 89, 97
            };

        // Act
        PrimeCountResultDto result = _service.CountPrimes(start, end, threadCount);

        // Assert
        Assert.That(result.PrimeCount, Is.EqualTo(expectedPrimes.Length));
        Assert.That(result.ThreadCount, Is.EqualTo(threadCount));
        Assert.That(result.FoundPrimes, Is.EquivalentTo(expectedPrimes));
    }

    /// <summary>
    /// Проверяет, что в диапазоне без простых чисел возвращается 0.
    /// </summary>
    [Test]
    public void CountPrimes_RangeWithoutPrimes_ShouldReturnZero()
    {
        // Arrange
        int start = 90;
        int end = 96;

        // Act
        PrimeCountResultDto result = _service.CountPrimes(start, end, 2);

        // Assert
        Assert.That(result.PrimeCount, Is.EqualTo(0));
        Assert.That(result.FoundPrimes, Is.Empty);
    }

    /// <summary>
    /// Проверяет подсчёт в полном диапазоне от 1 до 10000.
    /// Ожидаемое количество простых чисел: 1229.
    /// </summary>
    [Test]
    public void CountPrimes_FullRange_ShouldReturn1229Primes()
    {
        // Arrange
        int start = 1;
        int end = 10000;
        int threadCount = 4;

        // Act
        PrimeCountResultDto result = _service.CountPrimes(start, end, threadCount);

        // Assert
        Assert.That(result.PrimeCount, Is.EqualTo(1229));
        Assert.That(result.FoundPrimes.Count, Is.EqualTo(1229));
    }

    /// <summary>
    /// Проверяет, что DTO содержит правильные метаданные.
    /// </summary>
    [Test]
    public void CountPrimes_ResultDto_ShouldHaveCorrectMetadata()
    {
        // Arrange
        int start = 10;
        int end = 20;
        int threadCount = 3;

        // Act
        PrimeCountResultDto result = _service.CountPrimes(start, end, threadCount);

        // Assert
        Assert.That(result.SynchronizationType, Is.EqualTo("Semaphore"));
        Assert.That(result.ThreadCount, Is.EqualTo(threadCount));
        Assert.That(result.ExecutionTime, Is.GreaterThan(TimeSpan.Zero));
        Assert.That(result.FoundPrimes, Is.Not.Null);
    }

    /// <summary>
    /// Проверяет, что метод IsValid возвращает true при совпадении.
    /// </summary>
    [Test]
    public void IsValid_WithCorrectExpectedCount_ShouldReturnTrue()
    {
        // Arrange
        int start = 1;
        int end = 10;
        int expectedCount = 4;

        // Act
        PrimeCountResultDto result = _service.CountPrimes(start, end, 1);

        // Assert
        Assert.That(result.IsValid(expectedCount), Is.True);
    }

    /// <summary>
    /// Проверяет, что метод IsValid возвращает false при несовпадении.
    /// </summary>
    [Test]
    public void IsValid_WithIncorrectExpectedCount_ShouldReturnFalse()
    {
        // Arrange
        int start = 1;
        int end = 10;
        int wrongExpectedCount = 999;

        // Act
        PrimeCountResultDto result = _service.CountPrimes(start, end, 1);

        // Assert
        Assert.That(result.IsValid(wrongExpectedCount), Is.False);
    }

    /// <summary>
    /// Проверяет, что несколько запусков с одинаковыми параметрами дают одинаковый результат.
    /// </summary>
    [Test]
    public void CountPrimes_MultipleInvocations_ShouldReturnSameResult()
    {
        // Arrange
        int start = 1;
        int end = 50;

        // Act
        PrimeCountResultDto result1 = _service.CountPrimes(start, end, 2);
        PrimeCountResultDto result2 = _service.CountPrimes(start, end, 2);

        // Assert
        Assert.That(result1.PrimeCount, Is.EqualTo(result2.PrimeCount));
        Assert.That(result1.FoundPrimes, Is.EquivalentTo(result2.FoundPrimes));
    }
}
