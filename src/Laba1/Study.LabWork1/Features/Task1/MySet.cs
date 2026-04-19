using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace Study.LabWork1.Features.Task1;

/// <summary>
/// Обобщенный класс, представляющий математическое множество уникальных элементов.
/// </summary>
/// <typeparam name="T">Тип элементов множества.</typeparam>
public class MySet<T> : IEnumerable<T>
{
    // Внутреннее хранилище уникальных элементов.
    private readonly List<T> _items;

    /// <summary>
    /// Конструктор, принимающий коллекцию элементов.
    /// Сохраняются только уникальные значения, дубликаты игнорируются.
    /// </summary>
    /// <param name="collection">Исходная коллекция.</param>
    public MySet(IEnumerable<T> collection)
    {
        _items = new List<T>();

        // Проверяем, что коллекция не null
        if (collection == null)
            throw new ArgumentNullException(nameof(collection));

        // Проходим по каждому элементу входной коллекции
        foreach (var item in collection)
        {
            // Добавляем элемент, только если его еще нет в списке
            if (!_items.Contains(item))
            {
                _items.Add(item);
            }
        }
    }

    // Приватный конструктор для создания нового множества на основе готового списка.
    // Используется внутри операций, чтобы не дублировать логику проверки уникальности.
    private MySet(List<T> items)
    {
        // Предполагаем, что список уже содержит только уникальные элементы
        _items = items;
    }

    /// <summary>
    /// Свойство, возвращающее количество элементов в множестве.
    /// </summary>
    public int Count => _items.Count;

    /// <summary>
    /// Операция объединения множеств (A или B).
    /// Возвращает новый объект MySet, содержащий все элементы из A и B.
    /// </summary>
    public static MySet<T> operator |(MySet<T> left, MySet<T> right)
    {
        if (left == null || right == null)
            throw new ArgumentNullException();

        // Создаем новый список, копируя элементы левого множества
        var resultList = new List<T>(left._items);

        // Добавляем элементы из правого множества, которых еще нет
        foreach (var item in right._items)
        {
            if (!resultList.Contains(item))
            {
                resultList.Add(item);
            }
        }

        // Возвращаем новое множество
        return new MySet<T>(resultList);
    }

    /// <summary>
    /// Операция пересечения множеств (A и B).
    /// Возвращает НОВЫЙ объект MySet, содержащий элементы, присутствующие в обоих множествах.
    /// </summary>
    public static MySet<T> operator &(MySet<T> left, MySet<T> right)
    {
        if (left == null || right == null)
            throw new ArgumentNullException();

        var resultList = new List<T>();

        // Берем элементы из левого множества и проверяем, есть ли они в правом
        foreach (var item in left._items)
        {
            if (right._items.Contains(item))
            {
                resultList.Add(item);
            }
        }

        return new MySet<T>(resultList);
    }

    /// <summary>
    /// Операция разности множеств (A \ B).
    /// Возвращает НОВЫЙ объект MySet, содержащий элементы из A, которых нет в B.
    /// </summary>
    public static MySet<T> operator -(MySet<T> left, MySet<T> right)
    {
        if (left == null || right == null)
            throw new ArgumentNullException();

        var resultList = new List<T>();

        // Берем элементы из левого множества, которых нет в правом
        foreach (var item in left._items)
        {
            if (!right._items.Contains(item))
            {
                resultList.Add(item);
            }
        }

        return new MySet<T>(resultList);
    }

    /// <summary>
    /// Операция симметрической разности (A / B).
    /// Возвращает НОВЫЙ объект MySet, содержащий элементы, которые есть только в одном из множеств.
    /// (A \ B) или (B \ A)
    /// </summary>
    public static MySet<T> operator /(MySet<T> left, MySet<T> right)
    {
        if (left == null || right == null)
            throw new ArgumentNullException();

        var resultList = new List<T>();

        // Добавляем элементы из левого, которых нет в правом
        foreach (var item in left._items)
        {
            if (!right._items.Contains(item))
            {
                resultList.Add(item);
            }
        }

        // Добавляем элементы из правого, которых нет в левом
        foreach (var item in right._items)
        {
            if (!left._items.Contains(item))
            {
                resultList.Add(item);
            }
        }

        return new MySet<T>(resultList);
    }

    /// <summary>
    /// Проверка на равенство множеств.
    /// Сравнение происходит по значениям, а не по ссылкам.
    /// </summary>
    public static bool operator ==(MySet<T> left, MySet<T> right)
    {
        // Если оба null, они равны
        if (ReferenceEquals(left, null) && ReferenceEquals(right, null))
            return true;

        // Если один null, а другой нет - не равны
        if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
            return false;

        // Сравниваем количество элементов
        if (left.Count != right.Count)
            return false;

        // Проверяем, что каждый элемент левого множества есть в правом
        foreach (var item in left._items)
        {
            if (!right._items.Contains(item))
                return false;
        }

        return true;
    }

    /// <summary>
    /// Проверка на неравенство множеств.
    /// </summary>
    public static bool operator !=(MySet<T> left, MySet<T> right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Форматированный вывод множества в виде строки: {elem1, elem2, elem3}
    /// </summary>
    public override string ToString()
    {
        if (_items.Count == 0)
            return "{}";

        var sb = new StringBuilder();
        sb.Append('{');

        for (int i = 0; i < _items.Count; i++)
        {
            sb.Append(_items[i]);
            if (i < _items.Count - 1)
            {
                sb.Append(", ");
            }
        }

        sb.Append('}');
        return sb.ToString();
    }

    /// <summary>
    /// Возвращает перечислитель, который выполняет итерацию по элементам множества.
    /// </summary>
    /// <returns>Перечислитель для коллекции.</returns>
    public IEnumerator<T> GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /// <summary>
    /// Определяет, равен ли указанный объект текущему множеству.
    /// Сравнение происходит по содержимому, а не по ссылке.
    /// </summary>
    /// <param name="obj">Объект для сравнения с текущим множеством.</param>
    /// <returns>true, если объект является множеством с таким же набором элементов; иначе false.</returns>
    public override bool Equals(object obj)
    {
        if (obj is MySet<T> otherSet)
        {
            return this == otherSet;
        }
        return false;
    }

    /// <summary>
    /// Возвращает хеш-код для текущего множества.
    /// Хеш-код не зависит от порядка элементов.
    /// </summary>
    /// <returns>Хеш-код, вычисленный на основе элементов множества.</returns>
    public override int GetHashCode()
    {
        int hash = 0;
        foreach (var item in _items)
        {
            hash ^= item?.GetHashCode() ?? 0;
        }
        return hash;
    }
}

