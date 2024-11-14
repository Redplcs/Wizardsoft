using System.Text.Json;
using System.Text.Json.Serialization;

namespace Redplcs.Wizardsoft.Domain.JsonConverters;

public class JsonGuidArrayTreeItemListConverter : JsonConverter<List<TreeItem>>
{
	public override List<TreeItem>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new InvalidOperationException("This converter only works for serializing to GUIDs");
	}

	public override void Write(Utf8JsonWriter writer, List<TreeItem> value, JsonSerializerOptions options)
	{
		writer.WriteStartArray();

		foreach (var item in value)
		{
			var guid = item.Id;
			writer.WriteStringValue(guid);
		}

		writer.WriteEndArray();
	}
}
