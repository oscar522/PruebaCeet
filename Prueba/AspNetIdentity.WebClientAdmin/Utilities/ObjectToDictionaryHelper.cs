using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace AspNetIdentity.WebClientAdmin.Utilities
{
    public static class ObjectToDictionaryHelper
    {
        public static IDictionary<string, string> ToDictionary(this object source)
        {
            return source.ToDictionary<object>();
        }

        public static IDictionary<string, string> ToDictionary<T>(this object source)
        {
            if (source == null) ThrowExceptionWhenSourceArgumentIsNull();

            var dictionary = new Dictionary<string, string>();
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(source))
            {
                string value = property.GetValue(source).ToString();
                if (IsOfType<T>(value))
                {
                    dictionary.Add(property.Name, value);
                }
            }
            return dictionary;
        }

        private static bool IsOfType<T>(object value)
        {
            return value is T;
        }

        private static void ThrowExceptionWhenSourceArgumentIsNull()
        {
            throw new NullReferenceException("Unable to convert anonymous object to a dictionary. The source anonymous object is null.");
        }
    }
}