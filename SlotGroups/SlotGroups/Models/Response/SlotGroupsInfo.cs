namespace SlotGroups.Models.Response
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class SlotGroupsInfo
    {
        [JsonProperty("categoryName")]
        public string CategoryName { get; set; }

        [JsonProperty("eventName")]
        public string EventName { get; set; }

        [JsonProperty("slotGroups")]
        public List<SlotGroup> SlotGroups { get; set; }
    }

    public partial class SlotGroup
    {
        [JsonProperty("slotGroupName")]
        public string SlotGroupName { get; set; }

        [JsonProperty("resources")]
        public List<Resource> Resources { get; set; }
    }

    public partial class Resource
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("photo")]
        public Uri Photo { get; set; }

        [JsonProperty("certificates")]
        public List<string> Certificates { get; set; }
    }

    public partial class SlotGroupsInfo
    {
        public static SlotGroupsInfo FromJson(string json) => JsonConvert.DeserializeObject<SlotGroupsInfo>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this SlotGroupsInfo self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
