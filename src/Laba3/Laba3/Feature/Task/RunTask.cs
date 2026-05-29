using Microsoft.EntityFrameworkCore;
using Study.LabWork3.Feature.Task.Data;

namespace Study.LabWork3.Feature.Task
{
    /// <summary>
    /// Обёртка для запуска задания лабораторной работы 3.
    /// Настраивает и запускает Web API.
    /// </summary>
    public static class RunTask
    {
        /// <summary>
        /// Запускает веб-приложение книжного магазина.
        /// </summary>
        public static void Run()
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder();

            // Добавляем контроллеры с JSON-настройками
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
                });

            // Добавляем Swagger для документации API
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Настраиваем подключение к базе данных SQLite
            builder.Services.AddDbContext<BookStoreDbContext>(options =>
            {
                string dbPath = Path.Combine(AppContext.BaseDirectory, "bookstore.db");
                options.UseSqlite($"Data Source={dbPath}");
            });

            WebApplication app = builder.Build();

            // Создаём базу данных при запуске
            using (IServiceScope scope = app.Services.CreateScope())
            {
                BookStoreDbContext context = scope.ServiceProvider.GetRequiredService<BookStoreDbContext>();
                context.Database.EnsureCreated();
            }

            // Настраиваем конвейер middleware
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.MapControllers();
            app.MapGet("/", () => Results.Redirect("/swagger"));
            app.Run();
        }
    }
}
