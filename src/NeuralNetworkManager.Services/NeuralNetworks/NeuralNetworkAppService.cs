using CSharpNet;
using NeuralNetworkManager.Services.NeuralNetworks.Contracts;
using NeuralNetworkManager.Services.NeuralNetworks.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NeuralNetworkManager.Services.NeuralNetworks;

public class NeuralNetworkAppService : NeuralNetworkService
{
    private readonly NeuralNetworkRepository _networkRepository;

    public NeuralNetworkAppService(NeuralNetworkRepository networkRepository)
    {
        _networkRepository = networkRepository;
    }

    public async Task<string> Create(CreateNeuralNetworkDto dto)
    {
        var newNeuralNetwork = new DeepNetBuilder(dto.Layers, dto.LearningRate);

        var newId = Guid.NewGuid().ToString();
        await _networkRepository.Save(newId, newNeuralNetwork);

        return newId;
    }

    public async Task<double[]> Predict(string id, PredictOutputDto dto)
    {
        var model = await _networkRepository.Load(id);

        return model.FeedForward(dto.inputs);
    }

    public async Task<double> Train(string id, TrainModelDto dto)
    {
        var model = await _networkRepository.Load(id);

        var error = model.Backpropagate(dto.inputs, dto.expectedOutput);

        await _networkRepository.Save(id, model);

        return error;
    }

    public async Task<List<GetAllModelsDto>> GetAll()
    {
        return await _networkRepository.GetAll();
    }

    public void Delete(string id)
    {
        _networkRepository.Remove(id);
    }
}