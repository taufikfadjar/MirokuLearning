using System.Threading.Tasks;

namespace MirokuLearning.Business.Repository
{
    public interface IUnitOfWork
    {
        Task<int> AsyncSaveChange();
        void Dispose();
    }
}