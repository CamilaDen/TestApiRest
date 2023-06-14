using System.Text.Json.Serialization;
using System.Text.Json;

namespace TestApiRest.Validations
{
    public class ConvertirFecha : JsonConverter<DateTime>
    {
        private const string formatoFecha = "yyyy-MM-dd";

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string value = reader.GetString();
            return DateTime.ParseExact(value, formatoFecha, null);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(formatoFecha));
        }
    }
}
