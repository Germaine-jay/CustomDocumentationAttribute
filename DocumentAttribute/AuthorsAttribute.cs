using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentAttribute
{
    
    [AttributeUsage(AttributeTargets.All)]
    public class AuthorsAttribute : Attribute
    {
        protected string _Description;
        protected string _Output;
        protected string _Input;

        public AuthorsAttribute(string description, string Output="" , string Input = "")
        {
            _Description = description;
            _Input = Input;
            _Output = Output;
        }
    }
}

