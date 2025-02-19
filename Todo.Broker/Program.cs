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

builder.Services.AddSingleton<IAddTodoUseCase, AddTodoUseCase>();
builder.Services.AddSingleton<IGetTodosUseCase, GetTodosUserCase>();

builder.Services.AddSingleton<IGetTodosQueries, GetTodosQueries>();
builder.Services.AddSingleton<IAddTodoCommands, AddTodoCommands>();

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
