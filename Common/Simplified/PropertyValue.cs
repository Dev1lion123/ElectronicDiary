using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Simplified
{
    public static class PropertyValue
    {
        private static readonly Dictionary<Type, Dictionary<string, (MethodInfo set, MethodInfo get)>> Methods = new();

        private static (MethodInfo set, MethodInfo get)? GetMethods(Type type, string propertyName)
        {
            if (!Methods.TryGetValue(type, out Dictionary<string, (MethodInfo set, MethodInfo get)> dict))
            {
                dict = new();
                foreach (PropertyInfo property
                    in type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic).OfType<PropertyInfo>())
                {
                    try
                    {
                        dict.Add(property.Name,
                    (
                        property.SetMethod,
                        property.GetMethod
                    )); ;

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                }
                Methods.Add(type, dict);
            }

            return
                dict.TryGetValue(propertyName, out (MethodInfo set, MethodInfo get) methods)
                ? methods
                : null;
        }

        public static void SetValue(object obj, string propertyName, object value)
        {
            var methods = GetMethods(obj.GetType(), propertyName);
            methods.Value.set.Invoke(obj, new object[] { value });
        }
        public static object GetValue(object obj, string propertyName)
        {
            var methods = GetMethods(obj.GetType(), propertyName);
            return methods.Value.get.Invoke(obj, null);
        }

        public static IEnumerable<string> GetPropertyName(object obj)
        {
            _ = GetMethods(obj.GetType(), string.Empty);
            return Methods[obj.GetType()].Keys.ToArray();
        }
    }
}
