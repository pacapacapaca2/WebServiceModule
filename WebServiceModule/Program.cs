var builder = WebApplication.CreateBuilder(args);

// Добавление сервисов для контроллеров
builder.Services.AddControllers(); // Это необходимо для работы с контроллерами
builder.Services.AddEndpointsApiExplorer(); // Для поддержки Swagger
builder.Services.AddSwaggerGen(); // Для генерации Swagger-документации

var app = builder.Build();

// Настройка middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Маршруты для контроллеров
app.MapControllers(); // Подключение маршрутов для всех контроллеров

app.Run();
