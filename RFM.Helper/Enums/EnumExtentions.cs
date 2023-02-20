using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFM.Helper.Enums
{

    public static class EnumExtensions
    {
        public static string ToDescription(this Enum enumeration)
        {
            var type = enumeration.GetType();
            var memInfo = type.GetMember(enumeration.ToString());
            if (memInfo.Length > 0)
            {
                var attrs = memInfo[0].GetCustomAttributes(typeof(EnumDescription), false);
                if (attrs.Length > 0)
                    return ((EnumDescription)attrs[0]).Description;
            }
            return enumeration.ToString();
        }

        public static int GetIntValue(this Enum enumeration)
        {
            return Convert.ToInt32(enumeration);
        }

        public static bool GetBooleanValue(this Enum enumeration)
        {
            int i = Convert.ToInt32(enumeration);

            return (i > 0);
        }

        public static T FromEnumDescription<T>(this string description)
        {
            var type = typeof(T);
            if (!type.IsEnum)
                throw new Exception("Not Enum!");
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field, typeof(EnumDescription)) as EnumDescription;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else if (field.Name == description)
                    return (T)field.GetValue(null);
            }
            throw new ArgumentException("Enum not found!");
        }

        public static T ParseEnumFromName<T>(this string enumValue)
        {
            return (T)Enum.Parse(typeof(T), enumValue);
        }

        public static T[] ToArray<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToArray();
        }

        public static List<T> ToList<T>()
        {
            return new List<T>(ToArray<T>());
        }
    }

    public class EnumDescription : Attribute
    {
        public EnumDescription(string description)
        {
            Description = description;
        }

        public string Description { get; private set; }
    }
}

