using System;
using System.Collections.Generic;
using System.Text;
using Study.LabWork3.Abstractions.Feature.Task.Dtos;

namespace Study.LabWork3.Feature.Task.Entities
{
    /// <summary>
    /// Промежуточная таблица для связи многие ко многим между книгами и категориями.
    /// </summary>
    public class BookCategory
    {
        /// <summary>
        /// Внешний ключ на книгу.
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// Навигационное свойство: книга.
        /// </summary>
        public Book Book { get; set; } = null!;

        /// <summary>
        /// Внешний ключ на категорию.
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Навигационное свойство: категория.
        /// </summary>
        public Category Category { get; set; } = null!;
    }
}
