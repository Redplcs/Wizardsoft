using System.Text.Json.Serialization;
using Redplcs.Wizardsoft.Domain.JsonConverters;

namespace Redplcs.Wizardsoft.Domain;

public record TreeItem
{
	private TreeItem()
	{
	}

	public Guid Id { get; set; }

	[JsonConverter(typeof(JsonGuidTreeItemConverter))]
	public TreeItem? Parent { get; set; }

	[JsonConverter(typeof(JsonGuidArrayTreeItemListConverter))]
	public List<TreeItem> Children { get; set; } = [];

	public static TreeItem Create(Guid? id = null, TreeItem? parent = null, IEnumerable<TreeItem>? children = null)
	{
		return new TreeItem
		{
			Id = id ?? Guid.NewGuid(),
			Parent = parent,
			Children = new List<TreeItem>(children ?? [])
		};
	}
}
