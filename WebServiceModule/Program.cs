var builder = WebApplication.CreateBuilder(args);

// ���������� �������� ��� ������������
builder.Services.AddControllers(); // ��� ���������� ��� ������ � �������������
builder.Services.AddEndpointsApiExplorer(); // ��� ��������� Swagger
builder.Services.AddSwaggerGen(); // ��� ��������� Swagger-������������

var app = builder.Build();

// ��������� middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// �������� ��� ������������
app.MapControllers(); // ����������� ��������� ��� ���� ������������

app.Run();
