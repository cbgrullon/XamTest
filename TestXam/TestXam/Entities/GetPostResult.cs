using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
namespace TestXam.Entities
{
    public class GetPostResult
    {
        [JsonProperty("userId")]
        public long UserId { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }
    }
}
