using System.ComponentModel.DataAnnotations;

namespace Cgpt.Models
{
    public class OpenAiModels
    {
        [Required(ErrorMessage = "Model is required")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Prompt is required")]
        public string Prompt { get; set; }

        [Range(1, 100, ErrorMessage = "MaxTokens must be between 1 and 100")]
        public int MaxTokens { get; set; }

        [Range(0, 10, ErrorMessage = "Temperature must be between 0 and 10")]
        public double Temperature { get; set; }

        public OpenAiModel(string model, string prompt)
        {
            Model = model;
            Prompt = prompt;
        }
    }

    public class OpenAiResponse
    {
        [Required(ErrorMessage = "Completion is required")]
        public string Completion { get; set; }
    }
}