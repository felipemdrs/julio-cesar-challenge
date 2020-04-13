using Codenation_JulioCesarChallenge.Models;
using Newtonsoft.Json;
using System.IO;

namespace Codenation_JulioCesarChallenge
{
    class FileManager
    {
        private static readonly string AnswerFile = Path.Join(Path.GetTempPath(), "answer.json");

        public static void WriteFile(GenerateDataModel model)
        {
            var fileContent = JsonConvert.SerializeObject(model, Formatting.Indented);
            File.WriteAllText(AnswerFile, fileContent);
        }

        public static GenerateDataModel ReadFile()
        {
            var fileContent = File.ReadAllText(AnswerFile);
            return JsonConvert.DeserializeObject<GenerateDataModel>(fileContent);
        }

        public static FileStream GetFileStream()
        {
            return File.OpenRead(AnswerFile);
        }
    }
}
