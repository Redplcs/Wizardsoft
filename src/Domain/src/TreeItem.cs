namespace Redplcs.Wizardsoft.Domain;

public class TreeItem
{
	public Guid Id { get; set; }
	public TreeItem? Parent { get; set; }
	public List<TreeItem> Children { get; set; } = [];
}
