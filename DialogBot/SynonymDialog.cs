using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
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
    public class DictionaryDialog : IDialog<DictionaryParam>
    {

        DictionaryParam WP;

        public async Task StartAsync(IDialogContext context)
        {
            if (WP == null) WP = new DictionaryParam();
            context.Wait(MessageReceivedAsync);
        }

        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var message = await argument;
 
            var repl = await Reply(message.Text);
            await context.PostAsync(repl);
            context.Wait(MessageReceivedAsync);
        }

        async Task<string> Reply(string msg)
        {
            if (msg.Contains("en"))
                WP.Local = "en";
            if (msg.Contains("ру"))
                WP.Local = "ru";

            var a = msg.ToLower().Split(' ');
            
            WP.Location = a;
            return await WP.BuildResult();
        }
    }
}