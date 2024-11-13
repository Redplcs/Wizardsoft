using Microsoft.EntityFrameworkCore;
using Redplcs.Wizardsoft.Domain;

namespace Redplcs.Wizardsoft.Database;

public class ApplicationContext : DbContext
{
	public DbSet<TreeItem> Items => Set<TreeItem>();
}
