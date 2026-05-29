using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Study.LabWork3.Abstractions.Feature.Task.Dtos
{
    /// <summary>
    /// DTO для создания новой книги.
    /// </summary>
    public record CreateBookDto
    {
        /// <summary>
        /// Название книги.
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Title { get; init; } = string.Empty;

        /// <summary>
        /// Цена книги.
        /// </summary>
        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; init; }

        /// <summary>
        /// Год публикации.
        /// </summary>
        [Required]
        public int PublishYear { get; init; }

        /// <summary>
        /// Идентификатор автора.
        /// </summary>
        [Required]
        public int AuthorId { get; init; }

        /// <summary>
        /// Список идентификаторов категорий.
        /// </summary>
        public List<int> CategoryIds { get; init; } = new();
    }

    /// <summary>
    /// DTO для обновления существующей книги.
    /// </summary>
    public record UpdateBookDto
    {
        /// <summary>
        /// Название книги.
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Title { get; init; } = string.Empty;

        /// <summary>
        /// Цена книги.
        /// </summary>
        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; init; }

        /// <summary>
        /// Год публикации.
        /// </summary>
        [Required]
        public int PublishYear { get; init; }

        /// <summary>
        /// Идентификатор автора.
        /// </summary>
        [Required]
        public int AuthorId { get; init; }

        /// <summary>
        /// Список идентификаторов категорий.
        /// </summary>
        public List<int> CategoryIds { get; init; } = new();
    }

    /// <summary>
    /// DTO для чтения информации о книге.
    /// </summary>
    public record BookDto
    {
        /// <summary>
        /// Идентификатор книги.
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Название книги.
        /// </summary>
        public string Title { get; init; } = string.Empty;

        /// <summary>
        /// Цена книги.
        /// </summary>
        public decimal Price { get; init; }

        /// <summary>
        /// Год публикации.
        /// </summary>
        public int PublishYear { get; init; }

        /// <summary>
        /// Итендификатор автора
        /// </summary>
        public int AuthorId { get; init; }

        /// <summary>
        /// Имя автора.
        /// </summary>
        public string AuthorName { get; init; } = string.Empty;

        /// <summary>
        /// Список категорий книги.
        /// </summary>
        public List<string> CategoryNames { get; init; } = new();
    }
}
