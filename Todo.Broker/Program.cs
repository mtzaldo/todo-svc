using Todo.Broker.Domain.Entities;
using Todo.Broker.Features.Todo.AddTodo;
using Todo.Broker.Features.Todo.GetTodos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddHealthChecks();
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>();

builder.Services.AddScoped<IAddTodoUseCase, AddTodoUseCase>();
builder.Services.AddScoped<IGetTodosUseCase, GetTodosUserCase>();

builder.Services.AddScoped<IGetTodosQueries, GetTodosQueries>();
builder.Services.AddScoped<IAddTodoCommands, AddTodoCommands>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UsePathBase("/api");
app.UseRouting();
app.MapControllers().WithOpenApi();
app.MapHealthChecks("/health-check");

app.Run();
