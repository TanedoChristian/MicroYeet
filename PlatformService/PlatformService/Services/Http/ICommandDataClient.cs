using PlatformService.Dto;
using PlatformService.Entities;

namespace PlatformService.Services.Http
{
    public interface ICommandDataClient
    {
        Task SendPlatformToCommand(PlatformDto platform);
    }
}
