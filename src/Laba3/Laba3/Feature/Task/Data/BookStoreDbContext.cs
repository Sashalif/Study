using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Study.LabWork3.Feature.Task.Entities;

namespace Study.LabWork3.Feature.Task.Data
{
    /// <summary>
    /// Контекст базы данных книжного магазина.
    /// </summary>
    public class BookStoreDbContext : DbContext
    {
        /// <summary>
        /// Конструктор с параметрами конфигурации.
        /// </summary>
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Таблица авторов.
        /// </summary>
        public DbSet<Author> Authors { get; set; }

        /// <summary>
        /// Таблица книг.
        /// </summary>
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// Таблица категорий.
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Промежуточная таблица BookCategories.
        /// </summary>
        public DbSet<BookCategory> BookCategories { get; set; }

        /// <summary>
        /// Настройка модели и связей между таблицами.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Настройка составного первичного ключа для BookCategory
            modelBuilder.Entity<BookCategory>()
                .HasKey(bc => new { bc.BookId, bc.CategoryId });

            // Связь Book → BookCategory (один ко многим)
            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.BookCategories)
                .HasForeignKey(bc => bc.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            // Связь Category → BookCategory (один ко многим)
            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.BookCategories)
                .HasForeignKey(bc => bc.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // Начальные данные для авторов
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, FirstName = "Лев", LastName = "Толстой", BirthDate = new DateTime(1828, 9, 9), Country = "Россия" },
                new Author { Id = 2, FirstName = "Фёдор", LastName = "Достоевский", BirthDate = new DateTime(1821, 11, 11), Country = "Россия" },
                new Author { Id = 3, FirstName = "Джордж", LastName = "Оруэлл", BirthDate = new DateTime(1903, 6, 25), Country = "Великобритания" }
            );

            // Начальные данные для книг
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Война и мир", Price = 1500m, PublishYear = 1869, AuthorId = 1 },
                new Book { Id = 2, Title = "Анна Каренина", Price = 900m, PublishYear = 1877, AuthorId = 1 },
                new Book { Id = 3, Title = "Преступление и наказание", Price = 750m, PublishYear = 1866, AuthorId = 2 },
                new Book { Id = 4, Title = "1984", Price = 600m, PublishYear = 1949, AuthorId = 3 },
                new Book { Id = 5, Title = "Скотный двор", Price = 450m, PublishYear = 1945, AuthorId = 3 }
            );

            // Начальные данные для категорий
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Роман", Description = "Крупное эпическое произведение" },
                new Category { Id = 2, Name = "Антиутопия", Description = "Изображение негативного будущего" },
                new Category { Id = 3, Name = "Классика", Description = "Признанные шедевры мировой литературы" }
            );

            // Начальные данные для связей книг и категорий
            modelBuilder.Entity<BookCategory>().HasData(
                new BookCategory { BookId = 1, CategoryId = 1 },
                new BookCategory { BookId = 1, CategoryId = 3 },
                new BookCategory { BookId = 2, CategoryId = 1 },
                new BookCategory { BookId = 2, CategoryId = 3 },
                new BookCategory { BookId = 3, CategoryId = 1 },
                new BookCategory { BookId = 3, CategoryId = 3 },
                new BookCategory { BookId = 4, CategoryId = 2 },
                new BookCategory { BookId = 4, CategoryId = 3 },
                new BookCategory { BookId = 5, CategoryId = 2 }
            );
        }
    }
}
