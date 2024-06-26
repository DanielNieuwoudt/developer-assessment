using System;

namespace TodoList.Api
{
    public class TodoItem
    {
        public Guid Id { get; set; }

        public string Description { get; set; } = string.Empty;

        public bool IsCompleted { get; set; }
    }
}
