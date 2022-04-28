using System;

namespace Sketec.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class StringValueAttribute : Attribute
    {
        private string _value;
        public StringValueAttribute(string stringValue)
        {
            _value = stringValue;
        }

        public string StringValue { get { return _value; } }
    }
}
