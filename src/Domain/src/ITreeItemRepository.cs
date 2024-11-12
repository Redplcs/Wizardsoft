namespace Redplcs.Wizardsoft.Domain;

public interface ITreeItemRepository
{
	void Create(TreeItem item);
	TreeItem GetAll();
	TreeItem GetById(Guid id);
	void Update(TreeItem item);
	void Delete(TreeItem item);
}
