using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codenation_JulioCesarChallenge.Models
{
    class GenerateDataModel
    {
        [JsonProperty("numero_casas")]
        public int NumeroCasas { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("cifrado")]
        public string Cifrado { get; set; }
        [JsonProperty("decifrado")]
        public string Decifrado { get; set; }
        [JsonProperty("resumo_criptografico")]
        public string ResumoCriptografico { get; set; }
    }
}
