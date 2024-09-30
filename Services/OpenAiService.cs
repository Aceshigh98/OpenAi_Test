
using Cgpt.Models;
using Cgpt.Configurations;
using OpenAI.Chat;
using Microsoft.Extensions.Options;

namespace Cgpt.Services
{
    public class OpenAiService
    {

        public interface IOpenAiService
        {
            Task<string> GetCompletionAsync(OpenAiModels openAiModels);
        }

        private readonly OpenAiConfig _openAiConfig;

        public OpenAiService(IOptionsMonitor<OpenAiConfig> openAiConfig)
        {
            _openAiConfig = openAiConfig.CurrentValue;
        }

        public async Task<string> GetCompletionAsync(OpenAiModels openAiModels)
        {
            ChatClient client = new(model: "gpt-4o", _openAiConfig.Key);

            try
            {
                ChatCompletion result = await client.CompleteChatAsync(openAiModels.Prompt);

                Console.WriteLine("Response: " + result.ToString());

                return result.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
