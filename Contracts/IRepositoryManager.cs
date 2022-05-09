using Entities;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        ApplicationDbContext Context { get; }
        void Save();
        Task SaveAsync();
    }
}
