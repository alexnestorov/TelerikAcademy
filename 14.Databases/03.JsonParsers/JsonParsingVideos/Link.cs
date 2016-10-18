using Newtonsoft.Json;

namespace JsonParsingVideos
{
    public class Link : ILink
    {
        [JsonProperty("@href")]
        public string Href { get; set; }
    }
}
