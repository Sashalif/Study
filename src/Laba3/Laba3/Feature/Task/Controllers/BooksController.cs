using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.LabWork3.Abstractions.Feature.Task.Dtos;
using Study.LabWork3.Feature.Task.Data;
using Study.LabWork3.Feature.Task.Entities;
using System.Threading.Tasks;

namespace Study.LabWork3.Feature.Task.Controllers
{
    /// <summary>
    /// Контроллер для CRUD-операций с книгами.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BookStoreDbContext _context;

        /// <summary>
        /// Конструктор контроллера.
        /// </summary>
        public BooksController(BookStoreDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// CREATE: Создаёт новую книгу.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<BookDto>> Create([FromBody] CreateBookDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Author? author = await _context.Authors.FindAsync(dto.AuthorId);
            if (author == null)
                return BadRequest($"Автор с ID {dto.AuthorId} не найден");

            Book book = new Book
            {
                Title = dto.Title,
                Price = dto.Price,
                PublishYear = dto.PublishYear,
                AuthorId = dto.AuthorId
            };

            if (dto.CategoryIds?.Count > 0)
            {
                List<int> validCategoryIds = await _context.Categories
                    .Where(c => dto.CategoryIds.Contains(c.Id))
                    .Select(c => c.Id)
                    .ToListAsync();

                foreach (int categoryId in validCategoryIds)
                {
                    book.BookCategories.Add(new BookCategory
                    {
                        Book = book,
                        CategoryId = categoryId
                    });
                }
            }

            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            await LoadBookRelations(book);

            BookDto result = MapToDto(book);
            return CreatedAtAction(nameof(GetById), new { id = book.Id }, result);
        }

        /// <summary>
        /// READ: Возвращает список всех книг.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<BookDto>>> GetAll()
        {
            List<BookDto> books = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.BookCategories)
                    .ThenInclude(bc => bc.Category)
                .Select(b => MapToDto(b))
                .ToListAsync();

            return Ok(books);
        }

        /// <summary>
        /// READ: Возвращает книгу по идентификатору.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetById(int id)
        {
            Book? book = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.BookCategories)
                    .ThenInclude(bc => bc.Category)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
                return NotFound($"Книга с ID {id} не найдена");

            return Ok(MapToDto(book));
        }

        /// <summary>
        /// UPDATE: Обновляет данные книги.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult<BookDto>> Update(int id, [FromBody] UpdateBookDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Book? book = await _context.Books
                .Include(b => b.BookCategories)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
                return NotFound($"Книга с ID {id} не найдена");

            Author? author = await _context.Authors.FindAsync(dto.AuthorId);
            if (author == null)
                return BadRequest($"Автор с ID {dto.AuthorId} не найден");

            book.Title = dto.Title;
            book.Price = dto.Price;
            book.PublishYear = dto.PublishYear;
            book.AuthorId = dto.AuthorId;

            _context.BookCategories.RemoveRange(book.BookCategories);
            book.BookCategories.Clear();

            if (dto.CategoryIds?.Count > 0)
            {
                List<int> validCategoryIds = await _context.Categories
                    .Where(c => dto.CategoryIds.Contains(c.Id))
                    .Select(c => c.Id)
                    .ToListAsync();

                foreach (int categoryId in validCategoryIds)
                {
                    book.BookCategories.Add(new BookCategory
                    {
                        BookId = book.Id,
                        CategoryId = categoryId
                    });
                }
            }

            await _context.SaveChangesAsync();
            await LoadBookRelations(book);

            return Ok(MapToDto(book));
        }

        /// <summary>
        /// DELETE: Удаляет книгу по идентификатору.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Book? book = await _context.Books.FindAsync(id);
            if (book == null)
                return NotFound($"Книга с ID {id} не найдена");

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Загружает связанные данные книги (автор, категории).
        /// </summary>
        private async System.Threading.Tasks.Task LoadBookRelations(Book book)
        {
            await _context.Entry(book).Reference(b => b.Author).LoadAsync();
            await _context.Entry(book).Collection(b => b.BookCategories).LoadAsync();
            foreach (BookCategory bc in book.BookCategories)
            {
                await _context.Entry(bc).Reference(bcc => bcc.Category).LoadAsync();
            }
        }

        /// <summary>
        /// Преобразует сущность Book в DTO.
        /// </summary>
        private static BookDto MapToDto(Book book)
        {
            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Price = book.Price,
                PublishYear = book.PublishYear,
                AuthorName = book.Author != null
                    ? $"{book.Author.FirstName} {book.Author.LastName}"
                    : "Неизвестен",
                CategoryNames = book.BookCategories
                    ?.Select(bc => bc.Category?.Name ?? "Без категории")
                    .ToList() ?? new List<string>()
            };
        }
    }
}
