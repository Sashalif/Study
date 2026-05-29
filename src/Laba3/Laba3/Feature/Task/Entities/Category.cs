using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Study.LabWork3.Feature.Task.Entities
{
    /// <summary>
    /// Категория книг (жанр).
    /// Одна категория может содержать много книг (связь многие ко многим).
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Уникальный идентификатор категории.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Название категории.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Описание категории.
        /// </summary>
        [MaxLength(500)]
        public string? Description { get; set; }

        /// <summary>
        /// Книги, относящиеся к этой категории (связь многие ко многим).
        /// </summary>
        public ICollection<BookCategory> BookCategories { get; set; } = new List<BookCategory>();
    }
}
