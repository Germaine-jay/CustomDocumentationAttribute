using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DocumentAttribute
{
    public class CustomDocumentation
    {
        public static void GetClass(Type type)
        {
            var attributesz = type.GetCustomAttributes(typeof(DocumentAttribute), true);
            if (attributesz.Length > 0)
            {
                if (type.IsClass)
                {
                    Console.WriteLine("Class: {0}", type.Name);
                }
            }

            MethodInfo[] methods = type.GetMethods();
            foreach (MethodInfo method in methods)
            {
                var AttributesMethods = method.GetCustomAttributes(typeof(DocumentAttribute), true);

                if (AttributesMethods.Length > 0)
                {
                    Console.WriteLine("Method: {0}", method.Name);

                    Console.WriteLine("\tDescription: {0}", ((DocumentAttribute)AttributesMethods[0]).Description);
                    Console.WriteLine("\tInput: {0}", ((DocumentAttribute)AttributesMethods[0]).Input);
                    Console.WriteLine("\tOutput: {0}", ((DocumentAttribute)AttributesMethods[0]).Output);

                    Console.WriteLine("\n");
                }
            }

            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var AttributesProperty = property.GetCustomAttributes(typeof(DocumentAttribute), true);

                if (AttributesProperty.Length > 0)
                {
                    Console.WriteLine("Property: {0}", property.Name);
                    Console.WriteLine("\tDescription: {0}", ((DocumentAttribute)AttributesProperty[0]).Description);

                    Console.WriteLine("\n");
                }
            }

            ConstructorInfo[] constructorInfo = type.GetConstructors();
            foreach (ConstructorInfo constructor in constructorInfo)
            {
                var constructorAttributes = constructor.GetCustomAttributes(typeof(DocumentAttribute), true);
                if (constructorAttributes.Length > 0)
                {
                    Console.WriteLine("Constructor: {0}", constructor.Name);
                    Console.WriteLine("\tDescription: {0}", ((DocumentAttribute)constructorAttributes[0]).Description);
                    Console.WriteLine("\tInput: {0}", ((DocumentAttribute)constructorAttributes[0]).Input);

                    Console.WriteLine("\n");
                }
            }

            if (type.IsEnum)
            {
                Console.WriteLine("Enum: {0}", type.Name);

                string[] names = type.GetEnumNames();
                foreach (string name in names)
                {
                    Console.WriteLine("\t{0}", name);
                }
            }
        }
    }
    public class RunCustomDocumentation
    {
        public static void GetDocs()
        {
            var assembly = Assembly.GetExecutingAssembly();
            Type[] types = assembly.GetTypes();

            foreach (Type t in types)
            {
                CustomDocumentation.GetClass(t);
            }
        }
    }      
}
