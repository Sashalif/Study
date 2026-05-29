using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Study.LabWork3.Feature.Task.Entities
{
    /// <summary>
    /// Автор книги.
    /// Один автор может написать много книг (связь один ко многим).
    /// </summary>
    public class Author
    {
        /// <summary>
        /// Уникальный идентификатор автора.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Имя автора.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Фамилия автора.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Дата рождения автора.
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Страна происхождения.
        /// </summary>
        [MaxLength(50)]
        public string? Country { get; set; }

        /// <summary>
        /// Список книг автора (связь один ко многим).
        /// </summary>
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
