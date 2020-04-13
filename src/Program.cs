using System;
using System.Threading.Tasks;

namespace Codenation_JulioCesarChallenge
{
    class Program
    {
        private const string Token = "MEU_TOKEN";

        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            await JulioCesarChallenge.GenerateDataToFileAsync(Token);

            JulioCesarChallenge.DecryptAndSave();
            JulioCesarChallenge.HashDecryptedAndSave();

            await JulioCesarChallenge.SubmitFile(Token);
        }
    }
}
