using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DocumentAttribute
{
    public class CustomDocumentation
    {
        public static void GetClass()
        {
            var assembly = Assembly.GetExecutingAssembly();
            Console.WriteLine("\n");
            Console.WriteLine();
            var types = assembly.GetTypes();

            foreach (Type attrtype in types)
            {
                var attributes = attrtype.GetCustomAttributes(typeof(DocumentAttribute), true);
                if (attributes.Length > 0)
                {
                    if (attrtype.IsClass)
                    {
                        Console.WriteLine("Class: {0}", attrtype.Name);
                        Console.WriteLine("\tDescription: {0}", ((DocumentAttribute)attributes[0]).Description);

                    }

                    else if (attrtype.IsEnum)
                    {
                        Console.WriteLine("Enum: {0}", attrtype.Name);
                        Console.WriteLine("\tDescription: {0}", ((DocumentAttribute?)attributes.SingleOrDefault(x => x.GetType() == typeof(DocumentAttribute)))?.Description);

                        string[] names = attrtype.GetEnumNames();
                        foreach (string name in names)
                        {
                            Console.WriteLine(name);

                        }
                        Console.WriteLine();
                    }
                }
            }
        }

        public static void GetMethods(Type type)
        {

            MethodInfo[] methods = type.GetMethods();
            foreach (MethodInfo method in methods)
            {
                var AttributesMethods = method.GetCustomAttributes(typeof(DocumentAttribute), true);

                if (AttributesMethods.Length > 0)
                {
                    Console.WriteLine("Method: {0}", method.Name);

                    Console.WriteLine("\tDescription: {0}", ((DocumentAttribute)AttributesMethods[0]).Description);
                    Console.WriteLine("\tInput: {0}", ((DocumentAttribute)AttributesMethods[0]).Input);
                    Console.WriteLine("\tOutput: {0}",((DocumentAttribute)AttributesMethods[0]).Output);

                    Console.WriteLine("\n");
                }
            }
        }

        public static void GetProperties(Type type)
        {
            PropertyInfo[] properties = type.GetProperties().OrderBy(m => m.Name).ToArray();

            foreach (PropertyInfo property in properties)
            {
                var AttributesProperty = property.GetCustomAttributes(typeof(DocumentAttribute), true);

                if (AttributesProperty.Length > 0)
                {
                    Console.WriteLine("Property: {0}",property.Name);

                    Console.WriteLine("\tDescription: {0}",((DocumentAttribute)AttributesProperty[0]).Description);
                    Console.WriteLine("\tInput: {0}", ((DocumentAttribute)AttributesProperty[0]).Input);

                    Console.WriteLine("\n");
                }
            }
        }
        public static void GetConstructorInfo(Type type)
        {
            ConstructorInfo[] constructorInfo = type.GetConstructors();
            foreach (ConstructorInfo constructor in constructorInfo)
            {
                var constructorAttributes = constructor.GetCustomAttributes(typeof(DocumentAttribute), true);
                if (constructorAttributes.Length > 0)
                {
                    Console.WriteLine("Constructor: {0}",constructor.Name);

                    Console.WriteLine("\tDescription: {0}",((DocumentAttribute)constructorAttributes[0]).Description);
                    Console.WriteLine("\tInput: {0}",((DocumentAttribute)constructorAttributes[0]).Input);

                    Console.WriteLine("\n");
                }
            }
        }
    }
    public class RunCustomDocumentation : CustomDocumentation
    {
        public static void GetDocs(Type type)
        {
            GetClass();
            GetMethods(type);
            GetProperties(type);
            GetConstructorInfo(type);

            Console.WriteLine();
        }
    }      
}
