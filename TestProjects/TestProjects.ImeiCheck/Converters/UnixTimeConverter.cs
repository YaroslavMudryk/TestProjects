﻿using System.Text.Json;
using System.Text.Json.Serialization;

namespace TestProjects.ImeiCheck.Converters
{
    public class UnixTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            long unixTime = reader.GetInt64();
            return DateTimeOffset.FromUnixTimeSeconds(unixTime).DateTime;
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            long unixTime = new DateTimeOffset(value).ToUnixTimeSeconds();
            writer.WriteNumberValue(unixTime);
        }
    }
}
