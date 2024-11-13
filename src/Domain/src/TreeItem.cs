namespace Redplcs.Wizardsoft.Domain;

public class TreeItem
{
	private TreeItem()
	{
	}

	public Guid Id { get; set; }
	public TreeItem? Parent { get; set; }
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
