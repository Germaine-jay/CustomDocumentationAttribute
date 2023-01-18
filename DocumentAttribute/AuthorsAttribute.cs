using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentAttribute
{
    
    [AttributeUsage(AttributeTargets.All)]
    public class DocumentAttribute : Attribute
    {
        public string Description;
        public string Output;
        public string Input;

        public DocumentAttribute(string description)
        {
            Description = description;
            Input = null;
            Output = null;
        }
    }
}

