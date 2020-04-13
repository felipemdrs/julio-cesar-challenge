using Codenation_JulioCesarChallenge.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Codenation_JulioCesarChallenge
{
    class ChallengeAPI
    {
        private const string BaseUrl = "https://api.codenation.dev/v1/challenge/dev-ps";

        public static async Task<GenerateDataModel> GenerateDataAsync(string Token)
        {
            using (var client = new HttpClient())
            {
                var content = await client.GetStringAsync($"{BaseUrl}/generate-data?token={Token}");
                return JsonConvert.DeserializeObject<GenerateDataModel>(content);
            }
        }

        public static async Task SendGenerateDataAsync(string Token)
        {
            using (var client = new HttpClient())
            {
                using (var content = new MultipartFormDataContent())
                {
                    content.Add(new StreamContent(FileManager.GetFileStream()), "answer", "answer.JSON");

                    using (var message = await client.PostAsync($"{BaseUrl}/submit-solution?token={Token}", content))
                    {
                        Console.WriteLine(message.StatusCode);
                    }
                }
            }
        }
    }
}
