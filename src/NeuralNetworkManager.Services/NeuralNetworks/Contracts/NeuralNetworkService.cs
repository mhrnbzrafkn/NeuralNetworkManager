using NeuralNetworkManager.Services.Infrastructures;
using NeuralNetworkManager.Services.NeuralNetworks.Contracts.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NeuralNetworkManager.Services.NeuralNetworks.Contracts
{
    public interface NeuralNetworkService : Service
    {
        Task<string> Create(CreateNeuralNetworkDto dto);

        Task<double[]> Predict(string id, PredictOutputDto dto);

        Task<double> Train(string id, TrainModelDto dto);

        Task<List<GetAllModelsDto>> GetAll();
        void Delete(string id);
    }
}
