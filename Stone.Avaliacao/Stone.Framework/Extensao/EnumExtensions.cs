using System;
using System.ComponentModel;
using System.Linq;

namespace Stone.Framework.Extensao
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum enumValue)
        {
            var fi = enumValue.GetType().GetField(enumValue.ToString());

            var attrs = fi.GetCustomAttributes(typeof(DescriptionAttribute), true);

            if (attrs.Length > 0 && attrs.Any(x => x.GetType().Name == "DescriptionAttribute"))
                return ((DescriptionAttribute)attrs[0]).Description;

            throw new IndexOutOfRangeException(@"Não foi definido atributo 'Description' para esta enum.");
        }

        public static string GetDescriptionGenerico<TEnum>(this TEnum enumValue) where TEnum : struct, IConvertible
        {
            var fi = enumValue.GetType().GetField(enumValue.ToString());

            var attrs = fi.GetCustomAttributes(typeof(DescriptionAttribute), true);

            if (attrs.Length > 0 && attrs.Any(x => x.GetType().Name == "DescriptionAttribute"))
                return ((DescriptionAttribute)attrs[0]).Description;

            throw new IndexOutOfRangeException(@"Não foi definido atributo 'Description' para esta enum.");
        }

        public static string GetAttribute<TAttribute>(this Enum enumValue) where TAttribute : Attribute
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            var attributes = fieldInfo.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault();

            return attributes != null ? attributes.ToString() : null;
        }
    }
}
