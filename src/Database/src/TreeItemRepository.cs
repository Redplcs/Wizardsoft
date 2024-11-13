using Redplcs.Wizardsoft.Domain;

namespace Redplcs.Wizardsoft.Database;

public class TreeItemRepository(ApplicationContext context) : ITreeItemRepository
{
	private readonly ApplicationContext _context = context;

	public void Create(TreeItem item)
	{
		_context.Items.Add(item);
		_context.SaveChanges();
	}

	public void Delete(TreeItem item)
	{
		_context.Items.Remove(item);
		_context.SaveChanges();
	}

	public IEnumerable<TreeItem> GetAll()
	{
		return [.._context.Items];
	}

	public TreeItem? GetById(Guid id)
	{
		return _context.Items.FirstOrDefault(i => i.Id == id);
	}

	public void Update(TreeItem item)
	{
		_context.Items.Update(item);
		_context.SaveChanges();
	}
}
