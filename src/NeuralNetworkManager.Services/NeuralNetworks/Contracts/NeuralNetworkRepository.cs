using CSharpNet;
using NeuralNetworkManager.Services.Infrastructures;
using NeuralNetworkManager.Services.NeuralNetworks.Contracts.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NeuralNetworkManager.Services.NeuralNetworks.Contracts;

public interface NeuralNetworkRepository : Repository
{
    Task Save(string id, DeepNetBuilder model);
    Task<DeepNetBuilder> Load(string id);
    Task<List<GetAllModelsDto>> GetAll();
    void Remove(string id);
}