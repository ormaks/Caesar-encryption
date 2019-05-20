using System;
using System.Text;
using System.IO;

namespace Cezar
{
    
    public class CaesarCipher
    {
        const string Alphabet = "абвгґдеєжзиіїйклмнопрстуфхцчшщьюя";
//        const string Alphabet = "abcdefghijklmnopqrstuvwxyz";

        private static string CodeEncode(string text, int k)
        {
            var fullAlphabet = Alphabet + Alphabet.ToUpper();
            var letterQty = fullAlphabet.Length;
            var retVal = "";
            for (int i = 0; i < text.Length; i++)
            {
                var c = text[i];
                var index = fullAlphabet.IndexOf(c);
                if (index < 0)
                {
                    retVal += c.ToString();
                }
                else
                {
                    var codeIndex = (letterQty + index + k) % letterQty;
                    retVal += fullAlphabet[codeIndex];
                }
            }

            return retVal;
        }

        public string Encrypt(string plainMessage, int key)
            => CodeEncode(plainMessage, key);

        public string Decrypt(string encryptedMessage, int key)
            => CodeEncode(encryptedMessage, -key);
    }
    
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            string message = File.ReadAllText("../../Test.txt");

            var cipher = new CaesarCipher();
//            Console.Write("Введіть текст: ");
//            var message = Console.ReadLine();
            Console.Write("Введіть ключ: ");
            var secretKey = Convert.ToInt32(Console.ReadLine());
            var encryptedText = cipher.Encrypt(message, secretKey);
            File.WriteAllText("../../encrypted.txt", encryptedText);
            Console.WriteLine("Зашифроване повідомлення: {0}", encryptedText);
            Console.WriteLine("Розшифроване повідомлення: {0}", cipher.Decrypt(encryptedText, secretKey));
            Console.ReadLine();
        }
    }
}