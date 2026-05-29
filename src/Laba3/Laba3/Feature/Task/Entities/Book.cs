using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Study.LabWork3.Feature.Task.Entities
{
    /// <summary>
    /// Книга.
    /// Принадлежит одному автору (связь многие к одному).
    /// Может относиться к нескольким категориям (связь многие ко многим).
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Уникальный идентификатор книги.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Название книги.
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Цена книги в рублях.
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        /// <summary>
        /// Год публикации.
        /// </summary>
        public int PublishYear { get; set; }

        /// <summary>
        /// Внешний ключ на автора.
        /// </summary>
        [Required]
        public int AuthorId { get; set; }

        /// <summary>
        /// Навигационное свойство: автор книги.
        /// </summary>
        [ForeignKey(nameof(AuthorId))]
        public Author Author { get; set; } = null!;

        /// <summary>
        /// Категории, к которым относится книга (связь многие ко многим).
        /// </summary>
        public ICollection<BookCategory> BookCategories { get; set; } = new List<BookCategory>();
    }
}
