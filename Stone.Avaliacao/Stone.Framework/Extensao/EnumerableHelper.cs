using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Stone.Framework.Extensao
{
    public class EnumerableHelper
    {
        /// <summary>
        /// Get Enum List: key [description] and value [description]
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns>list</returns>
        public static IEnumerable<KeyValuePair<string, string>> EnumDescriptionParaLista<TEnum>()
        {
            var valores = new List<KeyValuePair<string, string>>();

            foreach (Enum e in Enum.GetValues(typeof(TEnum)))
            {
                var description = e.GetDescription();

                valores.Add(new KeyValuePair<string, string>(description, description));
            }

            return valores;
        }

        /// <summary>
        /// Get Enum List: key [seq/text] and value [text]
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="sequencial"></param>
        /// <returns>list</returns>
        public static IEnumerable<KeyValuePair<string, string>> EnumParaLista<TEnum>(bool sequencial = false)
            where TEnum : struct, IConvertible
        {
            if (!typeof(TEnum).IsEnum) throw new ArgumentException("TEnum precisa ser um tipo enumerado.");

            var valores = new List<KeyValuePair<string, string>>();

            foreach (var value in typeof(TEnum).GetFields())
            {
                if (value.Name.Equals("value__")) continue;

                var valor = sequencial ? value.GetRawConstantValue().ToString() : value.Name;

                valores.Add(new KeyValuePair<string, string>(valor, value.Name));
            }

            return valores;
        }

        public static IEnumerable<KeyValuePair<string, string>> EnumParaListaComSequencial<TEnum>()
            where TEnum : struct, IConvertible
        {
            return EnumParaLista<TEnum>(true);
        }

        /// <summary>
        /// Get Enum List: key [text] and value [description]
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns>list</returns>
        public static IEnumerable<KeyValuePair<string, string>> EnumDescriptionParaListaComTextoChave<TEnum>(bool inverter = false)
            where TEnum : struct, IConvertible
        {
            var valores = new List<KeyValuePair<string, string>>();

            foreach (Enum e in Enum.GetValues(typeof(TEnum)))
            {
                var description = e.GetDescription();

                valores.Add(!inverter
                    ? new KeyValuePair<string, string>(e.ToString(), description)
                    : new KeyValuePair<string, string>(description, e.ToString()));
            }

            return valores;
        }

        /// <summary>
        /// Get Enum List: key [seq] and value [description]
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns>list</returns>
        public static IEnumerable<KeyValuePair<string, string>> EnumParaListaComDescription<TEnum>()
            where TEnum : struct, IConvertible
        {
            if (!typeof(TEnum).IsEnum) throw new ArgumentException("TEnum precisa ser um tipo enumerado.");

            var valores = new List<KeyValuePair<string, string>>();

            foreach (var value in typeof(TEnum).GetFields())
            {
                if (value.Name.Equals("value__")) continue;

                var description = ((DescriptionAttribute)value
                    .GetCustomAttribute(typeof(DescriptionAttribute))).Description;

                valores.Add(new KeyValuePair<string, string>(value.GetRawConstantValue().ToString(), description));
            }

            return valores;
        }

        public static IList<TEnum> ObterTodosValoresEnums<TEnum>()
        {
            var opcoes = new List<TEnum>();

            foreach (var value in typeof(TEnum).GetFields())
            {
                if (value.Name.Equals("value__")) continue;

                opcoes.Add((TEnum)Enum.Parse(typeof(TEnum), value.Name));
            }

            return opcoes;
        }
    }
}
