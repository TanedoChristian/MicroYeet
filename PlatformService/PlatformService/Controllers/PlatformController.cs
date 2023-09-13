using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Dto;
using PlatformService.Entities;
using PlatformService.Repositories.PlatformRepository;
using PlatformService.Services.Http;

namespace PlatformService.Controllers
{
    public class PlatformController : BaseApiController
    {
        private readonly IPlatformRepository _platformRepository;
        private readonly IMapper _mapper;
        private readonly ICommandDataClient _commandDataClient;

        public PlatformController(IPlatformRepository platformRepository, IMapper mapper, ICommandDataClient commandDataClient)
        {
            _platformRepository = platformRepository;
            _mapper = mapper;
            _commandDataClient = commandDataClient;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllPlatforms()
        {
            return Ok(await _platformRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlatformById(int id)
        {
            return Ok(_platformRepository.GetById(id));
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeletePlatform(int id)
        {
            var platform = await _platformRepository.GetById(id);

            await _platformRepository.Delete(platform);

            return Ok("Success");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlatform(int id, PlatformDto platformDto)
        {
            var platform = await _platformRepository.GetById(id);

            _mapper.Map(platformDto, platform);
            await _platformRepository.Update(platform);

            return Ok(platform);
        }


        [HttpPost]
        public async Task<IActionResult> AddPlatform(PlatformDto platformDto)
        {
            var platform = _mapper.Map<Platform>(platformDto);
            await _platformRepository.Add(platform);

            try
            {
                await _commandDataClient.SendPlatformToCommand(platformDto);
            } catch (Exception ex)
            {
                Console.WriteLine($"Could not send async - {ex.Message}");
            }



            return Ok(platform);
        }
    }
}
