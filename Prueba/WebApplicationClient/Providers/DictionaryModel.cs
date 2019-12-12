using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;

namespace AspNetIdentity.WebClientAdmin.Providers
{
    public class DictionaryModel
    {
        public string Encode(DateTime date)
        {
            var formattedDate = date.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            return System.Net.WebUtility.UrlEncode(formattedDate);
        }


        public Dictionary<string, string> ToDictionary(object MyObject)
        {
            Dictionary<string, string> MyDictionary = new Dictionary<string, string>();

            string Valor = "";
            string nombre = "";

            foreach (PropertyDescriptor Descriptor in TypeDescriptor.GetProperties(MyObject))
            {
                nombre = Descriptor.Name;
                if (Descriptor.PropertyType.FullName.Equals("System.DateTime"))
                {
                    var valorDate = Descriptor.GetValue(MyObject).ToString();
                    DateTime parsedDate = DateTime.Parse(valorDate);
                    Valor = Encode(parsedDate);
                }
                else {
                    if (!Descriptor.GetValue(MyObject).ToString().Equals("null"))
                    {
                        Valor = Descriptor.GetValue(MyObject).ToString();
                    }
                    else {
                        Valor = "-";
                    }

                }


                MyDictionary.Add(nombre, Valor.ToString());
            }
            return MyDictionary;
        }

    }
}