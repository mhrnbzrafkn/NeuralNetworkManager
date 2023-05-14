using CSharpNet;
using NeuralNetworkManager.Services.NeuralNetworks.Contracts;
using NeuralNetworkManager.Services.NeuralNetworks.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NeuralNetworkManager.Repositories.NeuralNetworks;

public class NeuralNetworkJsonRepository : NeuralNetworkRepository
{
    private const string _pathToModelsFolder = ".\\Models\\";

    public async Task Save(string id, DeepNetBuilder model)
    {
        Directory.CreateDirectory(_pathToModelsFolder);
        string pathToModel = _pathToModelsFolder + $"{id}";

        await Task.Run(() => model.Save(pathToModel));
    }

    public async Task<DeepNetBuilder> Load(string id)
    {
        string pathToModel = _pathToModelsFolder + $"{id}";
        if (!Directory.Exists(_pathToModelsFolder))
        {
            if (!File.Exists(pathToModel))
            {
                throw new Exception("Model not found.");
            }
        }

        return await Task.Run(() => DeepNetBuilder.LoadModel(pathToModel));
    }

    public async Task<List<GetAllModelsDto>> GetAll()
    {
        if (Directory.Exists(_pathToModelsFolder))
        {
            string[] files = Directory.GetFiles(_pathToModelsFolder);

            return await Task.Run(() => files.Select(filePath => new GetAllModelsDto
            {
                Id = filePath.Split('\\').Last()
            }).ToList());
        }

        return new List<GetAllModelsDto>();
    }

    public void Remove(string id)
    {
        string pathToModel = _pathToModelsFolder + $"{id}";

        if (File.Exists(pathToModel))
        {
            File.Delete(pathToModel);
        }
    }
}