using System;

using Newtonsoft.Json;

namespace JsonParsingVideos
{
    public class Video : IVideo
    {
        public string Title { get; set; }

        public ILink Link { get; set; }

        [JsonProperty("yt:videoId")]
        public string Id { get; set; }

        public DateTime Published { get; set; }
    }
}
