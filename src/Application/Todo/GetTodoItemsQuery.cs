using Functions.Extension.Attributes;

namespace Application.Todo
{
    public class GetTodoItemsQuery
    {
        [RequestHeader("x-sampleHeader")]
        public string SampleHeader { get; set; }

        [RequestQuery("isStarted")]
        public bool IsStarted { get; set; }
    }
}
