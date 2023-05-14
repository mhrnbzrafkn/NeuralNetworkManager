using Microsoft.AspNetCore.Mvc;
using NeuralNetworkManager.Services.NeuralNetworks.Contracts;
using NeuralNetworkManager.Services.NeuralNetworks.Contracts.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NeuralNetworkManager.RestApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class NeuralNetworksController : ControllerBase
    {
        private readonly NeuralNetworkService _neuralNetworkService;

        public NeuralNetworksController(NeuralNetworkService neuralNetworkService)
        {
            _neuralNetworkService = neuralNetworkService;
        }

        [HttpPost("create")]
        public async Task<string> Create(CreateNeuralNetworkDto dto)
        {
            return await _neuralNetworkService.Create(dto);
        }

        [HttpGet("all")]
        public async Task<List<GetAllModelsDto>> GetAll()
        {
            return await _neuralNetworkService.GetAll();
        }

        [HttpPost("{id}/predict")]
        public async Task<double[]> Predict(string id, PredictOutputDto dto)
        {
            return await _neuralNetworkService.Predict(id, dto);
        }

        [HttpPatch("{id}/Train")]
        public async Task<double> Train(string id, TrainModelDto dto)
        {
            return await _neuralNetworkService.Train(id, dto);
        }

        [HttpDelete("{id}/delete")]
        public void Delete(string id)
        {
            _neuralNetworkService.Delete(id);
        }
    }
}