using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Stone.Domain.Models
{
    public static class Validations
    {
        public static bool ValidarMesEAnoDeValidadeDoCartao(string mes, string ano)
        {
            if (string.IsNullOrEmpty(mes) || string.IsNullOrEmpty(ano))
                return false;

            int month;
            int year;

            if (int.TryParse(mes, out month) && int.TryParse(ano, out year))
            {
                if (month >= 0 && month <= 12 && year >= DateTime.Now.Year)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool ValidarNumeroDoCartao(string numeroCartao)
        {
            if (string.IsNullOrEmpty(numeroCartao))
                return false;

            var regex = new Regex(@"\d{12,19}$");
            if (regex.IsMatch(numeroCartao))
            {
                return true;
            }

            return false;
        }
    }
}
