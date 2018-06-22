using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGEJ.Models.Repository.Interface
{
    public interface IDapperRepository<T> where T: class
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetDestaques();
        Task<IEnumerable<T>> GetAll(int id);
        Task<T> Get(int id);
    }
}