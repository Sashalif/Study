using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Study.LabWork3.Abstractions.Feature.Task.Dtos
{
    /// <summary>
    /// DTO для создания нового автора.
    /// </summary>
    public record CreateAuthorDto
    {
        /// <summary>
        /// Имя автора.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string FirstName { get; init; } = string.Empty;

        /// <summary>
        /// Фамилия автора.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string LastName { get; init; } = string.Empty;

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime? BirthDate { get; init; }

        /// <summary>
        /// Страна.
        /// </summary>
        [MaxLength(50)]
        public string? Country { get; init; }
    }

    /// <summary>
    /// DTO для обновления существующего автора.
    /// </summary>
    public record UpdateAuthorDto
    {
        /// <summary>
        /// Имя автора.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string FirstName { get; init; } = string.Empty;

        /// <summary>
        /// Фамилия автора.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string LastName { get; init; } = string.Empty;

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime? BirthDate { get; init; }

        /// <summary>
        /// Страна.
        /// </summary>
        [MaxLength(50)]
        public string? Country { get; init; }
    }

    /// <summary>
    /// DTO для чтения информации об авторе.
    /// </summary>
    public record AuthorDto
    {
        /// <summary>
        /// Идентификатор автора.
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Полное имя (Имя + Фамилия).
        /// </summary>
        public string FullName { get; init; } = string.Empty;

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime? BirthDate { get; init; }

        /// <summary>
        /// Страна.
        /// </summary>
        public string? Country { get; init; }

        /// <summary>
        /// Количество книг автора.
        /// </summary>
        public int BookCount { get; init; }
    }
}
