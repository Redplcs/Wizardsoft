using System.Text.Json;
using System.Text.Json.Serialization;

namespace Redplcs.Wizardsoft.Domain.JsonConverters;

public class JsonGuidTreeItemConverter : JsonConverter<TreeItem>
{
	public override TreeItem? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new InvalidOperationException("This converter only works for serializing to GUID");
	}

	public override void Write(Utf8JsonWriter writer, TreeItem value, JsonSerializerOptions options)
	{
		var guid = value.Id;
		writer.WriteStringValue(guid);
	}
}
