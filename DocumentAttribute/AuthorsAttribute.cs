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

        public DocumentAttribute(string description, string output="" , string input = "")
        {
            Description = description;
            Input = input;
            Output = output;
        }
    }
}

