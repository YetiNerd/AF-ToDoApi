using System;

namespace Functions.Extension.Attributes
{
    public class RequestQuery : Attribute
    {
        private string requestQueryName;

        public RequestQuery(string requestQueryName)
        {
            this.requestQueryName = requestQueryName;
        }

        public string GetName()
        {
            return this.requestQueryName;
        }
    }
}
