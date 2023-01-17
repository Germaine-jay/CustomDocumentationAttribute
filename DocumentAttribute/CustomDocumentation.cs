using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DocumentAttribute
{
    internal class CustomDocumentation
    {
        protected object Doctypes;
        public static void GetExeAssembly()
        {
            var assembly = Assembly.GetExecutingAssembly();
            Console.WriteLine("**** Documentation ****");
            var Doctypes = assembly.GetTypes();         
        }

        public static void GetDocumentation(Assembly asmb)
        {
            var Doctypes = asmb.GetTypes();

            foreach (Type type in Doctypes)
            {
                var attributes = type.GetCustomAttributes(typeof(AuthorsAttribute), true);

                if (attributes.Length > 0)
                {
                    if (type.IsClass)
                    {
                        Console.WriteLine("Class: " + type.Name);
                        Console.WriteLine("\tDescription: {0} ",((AuthorsAttribute)attributes[0])._Description);
                        Console.WriteLine();


                        foreach (ConstructorInfo constructor in type.GetConstructors())
                        {
                            var constructorAttributes = constructor.GetCustomAttributes(typeof(AuthorsAttribute), true);
                            if (constructorAttributes.Length > 0)
                            {
                                Console.WriteLine("Constructor: {0}",constructor.Name);
                                Console.WriteLine("\tDescription:{0} ",((AuthorsAttribute)constructorAttributes[0])._Description);
                                Console.WriteLine("\tInput: {0} ",((AuthorsAttribute)constructorAttributes[0])._Input);
                                Console.WriteLine();
                            }
                        }

                        foreach (MethodInfo method in type.GetMethods())
                        {
                            var methodAttributes = method.GetCustomAttributes(typeof(DocumentAttribute), true);
                            if (methodAttributes.Length > 0)
                            {
                                Console.WriteLine("Method: " + method.Name);
                                Console.WriteLine("\tDescription: " + ((DocumentAttribute)methodAttributes[0]).Description);
                                Console.WriteLine("\tInput: " + ((DocumentAttribute)methodAttributes[0]).Input);
                                Console.WriteLine("\tOutput: " + ((DocumentAttribute)methodAttributes[0]).Output);
                                Console.WriteLine();
                            }
                        }

                        foreach (PropertyInfo property in type.GetProperties())
                        {
                            var propertyAttributes = property.GetCustomAttributes(typeof(DocumentAttribute), true);
                            if (propertyAttributes.Length > 0)
                            {
                                Console.WriteLine("Property: " + property.Name);
                                Console.WriteLine("\tDescription: " + ((DocumentAttribute)propertyAttributes[0]).Description);
                                Console.WriteLine("\tOutput: " + ((DocumentAttribute)propertyAttributes[0]).Output);
                                Console.WriteLine();
                            }
                        }

                    }

                    if (type.IsEnum)
                    {
                        Console.WriteLine("Enum: " + type.Name);
                        Console.WriteLine("\tDescription: " + ((DocumentAttribute?)attributes.SingleOrDefault(a => a.GetType() == typeof(DocumentAttribute)))?.Description);

                        string[] names = type.GetEnumNames();
                        foreach (string name in names)
                        {
                            Console.WriteLine(name);

                        }
                        Console.WriteLine();
                    }

                }

            }
        }
        
    }
}
