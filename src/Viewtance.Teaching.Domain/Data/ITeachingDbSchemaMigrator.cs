using System.Threading.Tasks;

namespace Viewtance.Teaching.Data
{
    public interface ITeachingDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}