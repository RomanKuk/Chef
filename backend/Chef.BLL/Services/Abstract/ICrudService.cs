using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chef.BLL.Services.Abstract
{
    public interface ICrudService<TEntityDto, in TEntityCreateDto, in TKey> : IDisposable
        where TEntityDto : class
        where TEntityCreateDto : class
        where TKey : IEquatable<TKey>
    {
        Task<TEntityDto> AddAsync(TEntityCreateDto dto);
        Task UpdateAsync(TEntityDto dto);
        Task RemoveAsync(TKey id);
        Task<TEntityDto> GetAsync(TKey id, bool isNoTracking = false);
        Task<IEnumerable<TEntityDto>> GetAllAsync();
        Task<bool> ExistAsync(TKey id);
    }
}
