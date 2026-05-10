using Study.LabWork2.Abstractions.Feature.Task1.SubTask2.DtoModels;
using Study.LabWork2.Feature.Task1.SubTask2;

namespace Study.LabWork2.UnitTests.Feature.Task1.SubTask2;

/// <summary>
/// Проверяет многопоточную обработку наборов чисел
/// </summary>
[TestFixture]
public sealed class NumberSetProcessorTests
{
    /// <summary>
    /// Создаёт тестовые наборы: 5 наборов по 3 числа.
    /// Суммы: [6, 15, 24, 33, 42], общая = 120.
    /// </summary>
    private static List<int[]> CreateTestDataSets()
    {
        return new List<int[]>
            {
                new[] { 1, 2, 3 },      // Сумма = 6
                new[] { 4, 5, 6 },      // Сумма = 15
                new[] { 7, 8, 9 },      // Сумма = 24
                new[] { 10, 11, 12 },   // Сумма = 33
                new[] { 13, 14, 15 }    // Сумма = 42
            };
    }

    /// <summary>
    /// Проверяет, что конструктор не выбрасывает исключение при корректных параметрах.
    /// </summary>
    [Test]
    public void Constructor_WithValidParameters_ShouldCreateInstance()
    {
        // Arrange
        List<int[]> dataSets = CreateTestDataSets();

        // Act, Assert
        Assert.DoesNotThrow(() => new NumberSetProcessor(dataSets, 2));
    }

    /// <summary>
    /// Проверяет, что конструктор выбрасывает исключение при null вместо наборов.
    /// </summary>
    [Test]
    public void Constructor_WithNullDataSets_ShouldThrowArgumentNullException()
    {
        // Act, Assert
        Assert.Throws<ArgumentNullException>(() => new NumberSetProcessor(null, 2));
    }

    /// <summary>
    /// Проверяет, что GetResult выбрасывает исключение, если Process не был вызван.
    /// </summary>
    [Test]
    public void GetResult_BeforeProcess_ShouldThrowInvalidOperationException()
    {
        // Arrange
        List<int[]> dataSets = CreateTestDataSets();
        NumberSetProcessor processor = new NumberSetProcessor(dataSets, 2);

        // Act, Assert
        Assert.Throws<InvalidOperationException>(() => processor.GetResult());
    }

    /// <summary>
    /// Проверяет, что суммы всех наборов считаются правильно.
    /// </summary>
    [Test]
    public void Process_ShouldCalculateCorrectSums()
    {
        // Arrange
        List<int[]> dataSets = CreateTestDataSets();
        NumberSetProcessor processor = new NumberSetProcessor(dataSets, 2);

        // Act
        processor.Process();
        ProcessingResultDto result = processor.GetResult();

        // Assert
        Assert.That(result.Results.Count, Is.EqualTo(5));

        // Проверяем суммы по каждому набору
        int[] expectedSums = { 6, 15, 24, 33, 42 };
        for (int i = 0; i < expectedSums.Length; i++)
        {
            ResultEntryDto entry = result.Results.First(r => r.SetNumber == i + 1);
            Assert.That(entry.Sum, Is.EqualTo(expectedSums[i]),
                $"Набор {i + 1}: ожидалась сумма {expectedSums[i]}, получена {entry.Sum}");
        }
    }

    /// <summary>
    /// Проверяет, что общая сумма считается правильно.
    /// </summary>
    [Test]
    public void Process_ShouldCalculateCorrectTotalSum()
    {
        // Arrange
        List<int[]> dataSets = CreateTestDataSets();
        NumberSetProcessor processor = new NumberSetProcessor(dataSets, 2);

        // Act
        processor.Process();
        ProcessingResultDto result = processor.GetResult();

        // Assert
        // 6 + 15 + 24 + 33 + 42 = 120
        Assert.That(result.TotalSum, Is.EqualTo(120));
    }

    /// <summary>
    /// Проверяет, что количество обработанных наборов совпадает с количеством входных.
    /// </summary>
    [Test]
    public void Process_ShouldSetCorrectProcessedSetsCount()
    {
        // Arrange
        List<int[]> dataSets = CreateTestDataSets();
        NumberSetProcessor processor = new NumberSetProcessor(dataSets, 3);

        // Act
        processor.Process();
        ProcessingResultDto result = processor.GetResult();

        // Assert
        Assert.That(result.ProcessedSetsCount, Is.EqualTo(5));
    }

    /// <summary>
    /// Проверяет, что каждый результат содержит корректный номер набора.
    /// </summary>
    [Test]
    public void Process_EachResult_ShouldHaveCorrectSetNumber()
    {
        // Arrange
        List<int[]> dataSets = CreateTestDataSets();
        NumberSetProcessor processor = new NumberSetProcessor(dataSets, 2);

        // Act
        processor.Process();
        ProcessingResultDto result = processor.GetResult();

        // Assert
        List<int> setNumbers = result.Results.Select(r => r.SetNumber).OrderBy(n => n).ToList();
        Assert.That(setNumbers, Is.EqualTo(new[] { 1, 2, 3, 4, 5 }));
    }

    /// <summary>
    /// Проверяет, что время выполнения больше нуля.
    /// </summary>
    [Test]
    public void Process_ShouldSetNonZeroExecutionTime()
    {
        // Arrange
        List<int[]> dataSets = CreateTestDataSets();
        NumberSetProcessor processor = new NumberSetProcessor(dataSets, 2);

        // Act
        processor.Process();
        ProcessingResultDto result = processor.GetResult();

        // Assert
        Assert.That(result.ExecutionTime, Is.GreaterThan(TimeSpan.Zero));
    }

    /// <summary>
    /// Проверяет, что при 1 потоке все наборы обрабатываются последовательно.
    /// </summary>
    [Test]
    public void Process_WithSingleThread_ShouldWorkCorrectly()
    {
        // Arrange
        List<int[]> dataSets = CreateTestDataSets();
        NumberSetProcessor processor = new NumberSetProcessor(dataSets, 1);

        // Act
        processor.Process();
        ProcessingResultDto result = processor.GetResult();

        // Assert
        Assert.That(result.TotalSum, Is.EqualTo(120));
        Assert.That(result.ProcessedSetsCount, Is.EqualTo(5));
    }

    /// <summary>
    /// Проверяет, что при количестве потоков больше, чем наборов, работает корректно.
    /// </summary>
    [Test]
    public void Process_WithMoreThreadsThanSets_ShouldWorkCorrectly()
    {
        // Arrange
        List<int[]> dataSets = CreateTestDataSets(); // 5 наборов
        NumberSetProcessor processor = new NumberSetProcessor(dataSets, 10); // 10 потоков

        // Act
        processor.Process();
        ProcessingResultDto result = processor.GetResult();

        // Assert
        Assert.That(result.TotalSum, Is.EqualTo(120));
        Assert.That(result.ProcessedSetsCount, Is.EqualTo(5));
    }

    /// <summary>
    /// Проверяет обработку единственного набора.
    /// </summary>
    [Test]
    public void Process_WithSingleSet_ShouldReturnCorrectResult()
    {
        // Arrange
        List<int[]> dataSets = new List<int[]>
            {
                new[] { 10, 20, 30 }
            };
        NumberSetProcessor processor = new NumberSetProcessor(dataSets, 1);

        // Act
        processor.Process();
        ProcessingResultDto result = processor.GetResult();

        // Assert
        Assert.That(result.ProcessedSetsCount, Is.EqualTo(1));
        Assert.That(result.TotalSum, Is.EqualTo(60));
        Assert.That(result.Results[0].SetNumber, Is.EqualTo(1));
        Assert.That(result.Results[0].Sum, Is.EqualTo(60));
    }

    /// <summary>
    /// Проверяет обработку набора с пустым массивом чисел.
    /// </summary>
    [Test]
    public void Process_WithEmptyArray_ShouldReturnZeroSum()
    {
        // Arrange
        List<int[]> dataSets = new List<int[]>
            {
                new int[0] // Пустой массив
            };
        NumberSetProcessor processor = new NumberSetProcessor(dataSets, 1);

        // Act
        processor.Process();
        ProcessingResultDto result = processor.GetResult();

        // Assert
        Assert.That(result.ProcessedSetsCount, Is.EqualTo(1));
        Assert.That(result.TotalSum, Is.EqualTo(0));
        Assert.That(result.Results[0].Sum, Is.EqualTo(0));
    }
}
