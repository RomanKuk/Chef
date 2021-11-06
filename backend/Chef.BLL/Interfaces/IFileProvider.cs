using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Chef.BLL.Interfaces
{
    public interface IFileProvider
    {
        Task<string> UploadUserPhoto(IFormFile file);
    }
}
