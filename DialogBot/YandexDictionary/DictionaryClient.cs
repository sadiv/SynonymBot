using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Sadiv.Syn
{
    public class DictionaryClient
    {
        public string AppID { get; set; } = "";

        private HttpClient cli = new HttpClient();
        public DictionaryClient(string AppID)
        {
            this.AppID = AppID;
        }

        public async Task<string> Forecast(string[] text, string Local)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string word in text)
            {
                var res = await cli.GetStringAsync($"https://dictionary.yandex.net/api/v1/dicservice.json/lookup?key={AppID}&lang={Local}-{Local}&text={word}");

                var x = Newtonsoft.Json.JsonConvert.DeserializeObject<DictionaryRecord>(res);

                List<string> syns = new List<string>();
                if (x.def.Count > 0)
                {
                    foreach (var z in x.def[0].tr)
                    {
                        if (z.syn != null)
                        {
                            syns.Add(z.syn[0].text);
                        }              
                    }
                }
                if (syns.Count == 0)
                    sb.Append($"{word} ");
                else
                {
                    Random r = new Random();
                    sb.Append($"{syns[r.Next(0, syns.Count - 1)]} ");
                }
            }
          
            return sb.ToString();
        }
        
    }
}