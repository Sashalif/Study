using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Study.LabWork2.Feature.Task1.SubTask2
{
    /// <summary>
    /// Хранит 15 наборов по 100 случайных чисел от 1 до 100.
    /// </summary>
    public class DataSets
    {
        /// <summary>
        /// Список наборов чисел. Каждый набор — массив из 100 чисел.
        /// </summary>
        public List<int[]> Sets { get; set; } = new List<int[]>();

        // Путь к файлу с данными
        private const string DataFilePath = "datasets.json";

        /// <summary>
        /// Генерирует 15 наборов чисел с фиксированным seed и сохраняет в JSON-файл.
        /// </summary>
        public static void GenerateAndSave()
        {
            Random random = new Random(42); // Фиксированный seed для воспроизводимости
            DataSets data = new DataSets();

            for (int setIndex = 0; setIndex < 15; setIndex++)
            {
                int[] numbers = new int[100];
                for (int i = 0; i < 100; i++)
                {
                    numbers[i] = random.Next(1, 101); // Числа от 1 до 100
                }
                data.Sets.Add(numbers);
            }

            // Сохраняем в JSON
            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(DataFilePath, json);

            Console.WriteLine($"Сгенерировано 15 наборов и сохранено в {DataFilePath}");

            // Выводим наборы
            Console.WriteLine("\n=== Сгенерированные наборы (сохраните себе) ===");
            for (int i = 0; i < data.Sets.Count; i++)
            {
                Console.WriteLine($"Набор {i + 1}: {string.Join(" ", data.Sets[i])}");
            }
        }

        /// <summary>
        /// Загружает наборы данных из JSON-файла.
        /// </summary>
        /// <returns>Объект DataSets с наборами чисел.</returns>
        public static DataSets Load()
        {
            if (!File.Exists(DataFilePath))
            {
                throw new FileNotFoundException(
                    $"Файл {DataFilePath} не найден. Сначала запустите DataSets.GenerateAndSave().");
            }

            string json = File.ReadAllText(DataFilePath);
            DataSets data = JsonSerializer.Deserialize<DataSets>(json);

            return data;
        }
    }
}
