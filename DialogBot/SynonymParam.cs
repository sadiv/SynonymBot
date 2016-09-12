using Sadiv.Syn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DialogBot
{

    [Serializable]
    public class DictionaryParam
    {
        public string[] Location { get; set; }
        public string Local { get; set; }

        public DictionaryParam()
        {
            Location = new string[] { "Привет" };
            Local = "ru";
        }

        public async Task<string> BuildResult()
        {
            DictionaryClient YaD = new DictionaryClient(Config.OpenDictionaryAPIKey);
            var res = await YaD.Forecast(Location, Local);

            StringBuilder sb = new StringBuilder();
            sb.Append($"{res}\r\n");
            
            return sb.ToString();
        }
    }
}