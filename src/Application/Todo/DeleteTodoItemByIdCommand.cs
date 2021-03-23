using System;
using Functions.Extension.Attributes;

namespace Application.Todo
{
    public class DeleteTodoItemByIdCommand
    {
        [RequestPathParam("id")]
        public Guid Id { get; set; }
    }
}
