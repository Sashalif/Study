using System;
using System.Collections.Generic;
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
    /// Контроллер для CRUD-операций с категориями.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly BookStoreDbContext _context;

        /// <summary>
        /// Конструктор контроллера.
        /// </summary>
        public CategoriesController(BookStoreDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// CREATE: Создаёт новую категорию.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> Create([FromBody] CategoryDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Category category = new Category
            {
                Name = dto.Name,
                Description = dto.Description
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            CategoryDto result = MapToDto(category);
            return CreatedAtAction(nameof(GetById), new { id = category.Id }, result);
        }

        /// <summary>
        /// READ: Возвращает список всех категорий.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> GetAll()
        {
            List<CategoryDto> categories = await _context.Categories
                .Include(c => c.BookCategories)
                .Select(c => MapToDto(c))
                .ToListAsync();

            return Ok(categories);
        }

        /// <summary>
        /// READ: Возвращает категорию по идентификатору.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetById(int id)
        {
            Category? category = await _context.Categories
                .Include(c => c.BookCategories)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
                return NotFound($"Категория с ID {id} не найдена");

            return Ok(MapToDto(category));
        }

        /// <summary>
        /// UPDATE: Обновляет данные категории.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryDto>> Update(int id, [FromBody] UpdateCategoryDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Category? category = await _context.Categories.FindAsync(id);
            if (category == null)
                return NotFound($"Категория с ID {id} не найдена");

            category.Name = dto.Name;
            category.Description = dto.Description;

            await _context.SaveChangesAsync();
            await _context.Entry(category).Collection(c => c.BookCategories).LoadAsync();

            return Ok(MapToDto(category));
        }

        /// <summary>
        /// DELETE: Удаляет категорию по идентификатору.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Category? category = await _context.Categories.FindAsync(id);
            if (category == null)
                return NotFound($"Категория с ID {id} не найдена");

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Преобразует сущность Category в DTO.
        /// </summary>
        private static CategoryDto MapToDto(Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                BookCount = category.BookCategories?.Count ?? 0
            };
        }
    }
}
