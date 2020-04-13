using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Codenation_JulioCesarChallenge
{
    class JulioCesarChallenge
    {
        private const int MaxChar = 25;

        public static async Task GenerateDataToFileAsync(String token)
        {
            var generatedData = await ChallengeAPI.GenerateDataAsync(token);
            FileManager.WriteFile(generatedData);
        }

        public static void DecryptAndSave()
        {
            var generateDataModel = FileManager.ReadFile();
            var decrypted = DecryptText(generateDataModel.Cifrado, generateDataModel.NumeroCasas);

            generateDataModel.Decifrado = decrypted;

            FileManager.WriteFile(generateDataModel);
        }

        public static void HashDecryptedAndSave()
        {
            var generateDataModel = FileManager.ReadFile();
            var hash = HashText(generateDataModel.Decifrado);

            generateDataModel.ResumoCriptografico = hash.ToLower();

            FileManager.WriteFile(generateDataModel);
        }

        public static async Task SubmitFile(String token)
        {
            await ChallengeAPI.SendGenerateDataAsync(token);
        }

        private static string DecryptText(String text, int key)
        {
            var decrypted = string.Empty;

            foreach (var c in text)
            {
                if (IsValidChar(c))
                {
                    var charValue = (c - key % MaxChar);

                    if (charValue < 'a')
                    {
                        charValue = 'z' - ('a' - charValue - 1);
                    }

                    decrypted += Convert.ToChar(charValue);
                }
                else
                {
                    decrypted += c;
                }
            }

            return decrypted;
        }

        private static string HashText(string text)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(text));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }

        private static bool IsValidChar(char c)
        {
            return !Char.IsNumber(c) && !Char.IsPunctuation(c) && !Char.IsSeparator(c);
        }
    }
}
