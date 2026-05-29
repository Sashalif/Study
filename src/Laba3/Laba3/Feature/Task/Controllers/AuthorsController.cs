using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.LabWork3.Abstractions.Feature.Task.Dtos;
using Study.LabWork3.Feature.Task.Data;
using Study.LabWork3.Feature.Task.Entities;

namespace Study.LabWork3.Feature.Task.Controllers
{
    /// <summary>
    /// Контроллер для CRUD-операций с авторами.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly BookStoreDbContext _context;

        /// <summary>
        /// Конструктор контроллера.
        /// </summary>
        public AuthorsController(BookStoreDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// CREATE: Создаёт нового автора.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<AuthorDto>> Create([FromBody] CreateAuthorDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Author author = new Author
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                BirthDate = dto.BirthDate,
                Country = dto.Country
            };

            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            AuthorDto result = MapToDto(author);
            return CreatedAtAction(nameof(GetById), new { id = author.Id }, result);
        }

        /// <summary>
        /// READ: Возвращает список всех авторов.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<AuthorDto>>> GetAll()
        {
            List<AuthorDto> authors = await _context.Authors
                .Include(a => a.Books)
                .Select(a => MapToDto(a))
                .ToListAsync();

            return Ok(authors);
        }

        /// <summary>
        /// READ: Возвращает автора по идентификатору.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> GetById(int id)
        {
            Author? author = await _context.Authors
                .Include(a => a.Books)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (author == null)
                return NotFound($"Автор с ID {id} не найден");

            return Ok(MapToDto(author));
        }

        /// <summary>
        /// UPDATE: Обновляет данные автора.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult<AuthorDto>> Update(int id, [FromBody] UpdateAuthorDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Author? author = await _context.Authors.FindAsync(id);
            if (author == null)
                return NotFound($"Автор с ID {id} не найден");

            author.FirstName = dto.FirstName;
            author.LastName = dto.LastName;
            author.BirthDate = dto.BirthDate;
            author.Country = dto.Country;

            await _context.SaveChangesAsync();
            await _context.Entry(author).Collection(a => a.Books).LoadAsync();

            return Ok(MapToDto(author));
        }

        /// <summary>
        /// DELETE: Удаляет автора по идентификатору.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Author? author = await _context.Authors.FindAsync(id);
            if (author == null)
                return NotFound($"Автор с ID {id} не найден");

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Преобразует сущность Author в DTO.
        /// </summary>
        private static AuthorDto MapToDto(Author author)
        {
            return new AuthorDto
            {
                Id = author.Id,
                FullName = $"{author.FirstName} {author.LastName}",
                BirthDate = author.BirthDate,
                Country = author.Country,
                BookCount = author.Books?.Count ?? 0
            };
        }
    }
}
