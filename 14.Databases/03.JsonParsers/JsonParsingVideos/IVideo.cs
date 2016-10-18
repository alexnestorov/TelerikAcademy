using System;

namespace JsonParsingVideos
{
    public interface IVideo
    {
        string Title { get; }

        ILink Link { get; }

        string Id { get; }

        DateTime Published { get; }
    }
}
