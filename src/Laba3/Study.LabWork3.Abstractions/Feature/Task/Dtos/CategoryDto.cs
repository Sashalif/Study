using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Study.LabWork3.Abstractions.Feature.Task.Dtos
{
    /// <summary>
    /// DTO для создания новой категории.
    /// </summary>
    public record CreateCategoryDto
    {
        /// <summary>
        /// Название категории.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; init; } = string.Empty;

        /// <summary>
        /// Описание категории.
        /// </summary>
        [MaxLength(500)]
        public string? Description { get; init; }
    }

    /// <summary>
    /// DTO для обновления существующей категории.
    /// </summary>
    public record UpdateCategoryDto
    {
        /// <summary>
        /// Название категории.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; init; } = string.Empty;

        /// <summary>
        /// Описание категории.
        /// </summary>
        [MaxLength(500)]
        public string? Description { get; init; }
    }

    /// <summary>
    /// DTO для чтения информации о категории.
    /// </summary>
    public record CategoryDto
    {
        /// <summary>
        /// Идентификатор категории.
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Название категории.
        /// </summary>
        public string Name { get; init; } = string.Empty;

        /// <summary>
        /// Описание категории.
        /// </summary>
        public string? Description { get; init; }

        /// <summary>
        /// Количество книг в категории.
        /// </summary>
        public int BookCount { get; init; }
    }
}
