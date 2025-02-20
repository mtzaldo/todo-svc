using Todo.Broker.Domain.Entities;
using Todo.Broker.Features.Todo.AddTodo;
using Todo.Broker.Features.Todo.GetTodos;
using Todo.Broker.Features.Todo.RemoveTodo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddHealthChecks();
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>();

builder.Services.AddScoped<IAddTodoUseCase, AddTodoUseCase>();
builder.Services.AddScoped<IGetTodosUseCase, GetTodosUserCase>();
builder.Services.AddScoped<IRemoveTodoUseCase, RemoveTodoUseCase>();

builder.Services.AddScoped<IGetTodosQueries, GetTodosQueries>();
builder.Services.AddScoped<IAddTodoCommands, AddTodoCommands>();
builder.Services.AddScoped<IRemoveTodoCommands, RemoveTodoCommands>();

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
