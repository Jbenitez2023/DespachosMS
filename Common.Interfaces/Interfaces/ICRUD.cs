using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces.Interfaces
{
    public interface ICRUD<TRequest,Tresponse>
    {
        public Task<IEnumerable<Tresponse>> GetAllAsync();
        public Task<Tresponse> GetByIdAsync(int id);
        public Task<Tresponse> AddAsync(TRequest entity);
        public Task<Tresponse> UpdateAsync(Tresponse entity);
        public Task<bool> DeleteAsync(int id);
    }
}
