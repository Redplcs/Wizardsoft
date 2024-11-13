using Microsoft.EntityFrameworkCore;
using Redplcs.Wizardsoft.Domain;

namespace Redplcs.Wizardsoft.Database;

public class ApplicationContext(DbContextOptions options) : DbContext(options)
{
	public DbSet<TreeItem> Items => Set<TreeItem>();
}
