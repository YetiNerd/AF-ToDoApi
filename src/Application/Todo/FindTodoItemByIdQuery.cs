using System;
using Functions.Extension.Attributes;

namespace Application.Todo
{
    public class FindTodoItemByIdQuery
    {
        [RequestPathParam("id")]
        public Guid Id { get; set; }
    }
}
