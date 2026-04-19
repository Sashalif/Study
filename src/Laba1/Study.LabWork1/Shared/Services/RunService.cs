using Study.LabWork1.Features.Task1;
using Study.LabWork1.Shared.Abstractions;

namespace Study.LabWork1.Shared.Services;

/// <summary>
/// Реализация заданий Л/Р
/// </summary>
public class RunService : IRunService
{
    /// <summary>
    /// Задание 1
    /// </summary>
    public void RunTask1()
    {
        var set1 = new MySet<int>([1, 2, 2, 3, 4]);
        var set2 = new MySet<int>([3, 4, 4, 5, 6]);
        var set3 = new MySet<int>([1, 2, 3, 4]);

        Console.WriteLine($"Множество A: {set1}");      // {1, 2, 3, 4}
        Console.WriteLine($"Множество B: {set2}");      // {3, 4, 5, 6}
        Console.WriteLine($"Множество C: {set3}");      // {1, 2, 3, 4}

        // Тестируем операции
        var union = set1 | set2;
        Console.WriteLine($"Объединение A и B: {union}");     // {1, 2, 3, 4, 5, 6}

        var intersect = set1 & set2;
        Console.WriteLine($"Пересечение A и B: {intersect}"); // {3, 4}

        var diff = set1 - set2;
        Console.WriteLine($"Разность A\\B: {diff}");    // {1, 2}

        var symDiff = set1 / set2;
        Console.WriteLine($"Симм. разность A и B: {symDiff}"); // {1, 2, 5, 6}

        // Проверка равенства
        
        Console.WriteLine($"A == C: {set1 == set3}");   // True
        Console.WriteLine($"A == B: {set1 == set2}");   // False
    }

    /// <summary>
    /// Задание 2
    /// </summary>
    public void RunTask2() => throw new NotImplementedException();

    /// <summary>
    /// Задание 3
    /// </summary>
    public void RunTask3() => throw new NotImplementedException();
}
