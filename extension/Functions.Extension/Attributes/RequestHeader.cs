using System;

namespace Functions.Extension.Attributes
{
    public class RequestHeader : Attribute
    {
        private string requestHeaderName;

        public RequestHeader(string requestHeaderName)
        {
            this.requestHeaderName = requestHeaderName;
        }

        public string GetName()
        {
            return this.requestHeaderName;
        }
    }
}
