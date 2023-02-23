using Newtonsoft.Json;

namespace RadioBrowser.Net.Converters;

public class CommaSeparatedConverter : JsonConverter {
    public override bool CanConvert(Type objectType) => throw new NotImplementedException();

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer) => (reader.Value is null) ? Enumerable.Empty<string>() : reader.Value.ToString()!.Split(",");

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer) => throw new NotImplementedException();
}
