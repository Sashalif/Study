using Study.LabWork2.Abstractions.Feature.Task1.SubTask1;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1.DtoModels;
using Study.LabWork2.Feature.Task1.SubTask1;
using Study.LabWork2.Feature.Task1.SubTask2;


namespace Study.LabWork2;

/// <summary>
/// Запускает все три версии подсчёта простых чисел.
/// </summary>
public static class Program
{
    /// <summary>
    /// Точка входа в программу.
    /// </summary>
    public static void Main()
    {
        // Задание 1.1: Подсчёт простых чисел с разными методами синхронизации
        TaskRun1_1.Run();

        //Задание 1.2: Обработка наборов чисел разными потоками.
        // Если файла с данными нет — генерируем
        if (!File.Exists("datasets.json"))
        {
            Console.WriteLine("Файл с данными не найден. Генерирую новые наборы...\n");
            DataSets.GenerateAndSave();
            Console.WriteLine("\nНаборы сгенерированы. Запустите программу снова для подсчёта.");
            Console.ReadKey();
            return;
        }

        // Запуск заданий
        TaskRun1_2.Run();
    }
}
