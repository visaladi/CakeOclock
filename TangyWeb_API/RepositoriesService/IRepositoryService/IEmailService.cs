using JWTDemo.Shared.DTOs;

namespace TangyWeb_API.RepositoriesService.IRepositoryService
{
    public interface IEmailService
    {
        Task<string> SendEmail(RequestDTO requestDTO);
    }
}

