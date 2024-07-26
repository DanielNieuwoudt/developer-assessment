﻿using TodoList.Domain.TodoItems;
using TodoList.Domain.TodoItems.ValueObjects;

namespace TodoList.Application.Contracts
{
    public interface ITodoItemsRepository
    {
        Task<TodoItem> CreateTodoItemAsync(TodoItem todoItem, CancellationToken cancellationToken);

        Task<bool> FindByIdAsync(TodoItemId todoItemId, CancellationToken cancellationToken);

        Task<bool> FindByDescriptionAsync(string description, CancellationToken cancellationToken);

        Task<TodoItem?> GetTodoItemAsync(TodoItemId todoItemId, CancellationToken cancellationToken);

        Task<IEnumerable<TodoItem>> GetTodoItemsAsync(CancellationToken cancellationToken);

        Task UpdateTodoItemAsync(TodoItem todoItem, CancellationToken cancellationToken);
    }
}
