namespace TelerikAcademyForum
{
    using Newtonsoft.Json;

    public class Question
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }
    }
}
