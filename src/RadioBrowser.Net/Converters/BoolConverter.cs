using Newtonsoft.Json;

namespace RadioBrowser.Net.Converters;

public class BoolConverter : JsonConverter {
    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer) => throw new NotImplementedException();

    public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer) => reader.Value is not null && reader.Value.ToString() == "1";

    public override bool CanConvert(Type objectType) => throw new NotImplementedException();
}
