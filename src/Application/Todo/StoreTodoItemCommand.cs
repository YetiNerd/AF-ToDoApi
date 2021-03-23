using Domain;

namespace Application.Todo
{
    public class StoreTodoItemCommand
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsStarted { get; set; }

        public bool IsFinished { get; set; }

        public TodoList List { get; set; }
    }
}
