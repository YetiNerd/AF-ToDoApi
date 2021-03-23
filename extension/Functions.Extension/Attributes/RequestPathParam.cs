using System;

namespace Functions.Extension.Attributes
{
    public class RequestPathParam : Attribute
    {
        private string requestPathName;

        public RequestPathParam(string requestPathName)
        {
            this.requestPathName = requestPathName;
        }

        public string GetName()
        {
            return this.requestPathName;
        }
    }
}