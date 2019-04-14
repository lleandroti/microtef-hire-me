using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Stone.Framework.Security
{
    public static class CriptografiaAESHelper
    {
        /// <summary>     
        /// Vetor de bytes utilizados para a criptografia (Chave Externa)     
        /// </summary>     
        private static readonly byte[] bIV = { 0x50, 0x08, 0xF1, 0xDD, 0xDE, 0x3C, 0xF2, 0x18 };

        /// <summary>     
        /// Representação de valor em base 64 (Chave Interna)
        /// </summary>     
        private const string cryptoKey = "mvAsrtUgMRZvEMCxrB7VPJJW94ahdy87";

        /// <summary>
        /// Define o tamanho da chave "256 = 8 * 32"                
        /// Lembre-se: chaves possíves:                
        /// 128 (16 caracteres), 192 (24 caracteres) e 256 (32 caracteres
        /// </summary>
        private const int KeySize = (int)KeySizeCriptografiaAES.Key128;

        /// <summary>     
        /// Metodo de criptografia de valor     
        /// </summary>     
        /// <param name="textoNormal">valor a ser criptografado</param>
        /// <returns>valor criptografado</returns>
        public static string Criptografar(string textoNormal)
        {
            if (string.IsNullOrEmpty(textoNormal))
                return string.Empty;

            var vetorInicializacao = ArrayBytesToHexString(bIV);

            return Encriptar(cryptoKey, vetorInicializacao, textoNormal);
        }

        /// <summary>     
        /// Pega um valor previamente criptografado e retorna o valor inicial 
        /// </summary>     
        /// <param name="textoEncriptado">texto criptografado</param>     
        /// <returns>valor descriptografado</returns> 
        public static string Descriptografar(string textoEncriptado)
        {
            if (string.IsNullOrEmpty(textoEncriptado))
                return string.Empty;

            var vetorInicializacao = ArrayBytesToHexString(bIV);

            return Decriptar(cryptoKey, vetorInicializacao, textoEncriptado);
        }

        private static Rijndael CriarInstanciaRijndael(string chave, string vetorInicializacao)
        {
            if (!(chave != null && (chave.Length == 16 || chave.Length == 24 || chave.Length == 32)))
            {
                throw new Exception("A chave de criptografia deve possuir 16, 24 ou 32 caracteres.");
            }

            if (vetorInicializacao == null || vetorInicializacao.Length != 16)
            {
                throw new Exception("O vetor de inicialização deve possuir 16 caracteres.");
            }

            var algoritmo = Rijndael.Create();

            algoritmo.KeySize = KeySize;
            algoritmo.Key = Encoding.ASCII.GetBytes(chave);
            algoritmo.IV = Encoding.ASCII.GetBytes(vetorInicializacao);

            return algoritmo;
        }

        private static string Encriptar(string chave, string vetorInicializacao, string textoNormal)
        {
            if (string.IsNullOrWhiteSpace(textoNormal))
            {
                throw new Exception("O conteúdo a ser encriptado não pode ser uma string vazia.");
            }

            using (Rijndael algoritmo = CriarInstanciaRijndael(chave, vetorInicializacao))
            {
                ICryptoTransform encryptor = algoritmo.CreateEncryptor(algoritmo.Key, algoritmo.IV);

                using (var streamResultado = new MemoryStream())
                {
                    using (var csStream = new CryptoStream(streamResultado, encryptor, CryptoStreamMode.Write))
                    {
                        using (var writer = new StreamWriter(csStream))
                        {
                            writer.Write(textoNormal);
                        }
                    }

                    return ArrayBytesToHexString(streamResultado.ToArray());
                }
            }
        }

        private static string ArrayBytesToHexString(byte[] conteudo)
        {
            string[] arrayHex = Array.ConvertAll(conteudo, b => b.ToString("X2"));

            return string.Concat(arrayHex);
        }

        private static string Decriptar(string chave, string vetorInicializacao, string textoEncriptado)
        {
            if (string.IsNullOrWhiteSpace(textoEncriptado))
            {
                throw new Exception("O conteúdo a ser decriptado não pode ser uma string vazia.");
            }

            if (textoEncriptado.Length % 2 != 0)
            {
                throw new Exception("O conteúdo a ser decriptado é inválido.");
            }

            using (Rijndael algoritmo = CriarInstanciaRijndael(chave, vetorInicializacao))
            {
                ICryptoTransform decryptor =
                    algoritmo.CreateDecryptor(algoritmo.Key, algoritmo.IV);

                string textoDecriptografado;

                using (var streamTextoEncriptado = new MemoryStream(HexStringToArrayBytes(textoEncriptado)))
                {
                    using (var csStream = new CryptoStream(streamTextoEncriptado, decryptor, CryptoStreamMode.Read))
                    {
                        using (var reader = new StreamReader(csStream))
                        {
                            textoDecriptografado = reader.ReadToEnd();
                        }
                    }
                }

                return textoDecriptografado;
            }
        }

        private static byte[] HexStringToArrayBytes(string conteudo)
        {
            int qtdeBytesEncriptados = conteudo.Length / 2;
            byte[] arrayConteudoEncriptado = new byte[qtdeBytesEncriptados];

            for (int i = 0; i < qtdeBytesEncriptados; i++)
            {
                arrayConteudoEncriptado[i] = Convert.ToByte(conteudo.Substring(i * 2, 2), 16);
            }

            return arrayConteudoEncriptado;
        }
    }

    public enum KeySizeCriptografiaAES
    {
        [Description("16 caracteres")]
        Key128 = 128,
        [Description("24 caracteres")]
        Key192 = 192,
        [Description("32 caracteres")]
        Key256 = 256
    }
}