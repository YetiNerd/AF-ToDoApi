using System;

namespace Domain
{
    public class TodoItem
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsStarted { get; set; }

        public bool IsFinished { get; set; }

        public TodoList List { get; set; }
    }
}
