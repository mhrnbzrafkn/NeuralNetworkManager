using CSharpNet;
using CSharpNet.Infrastructures;
using System.Collections.Generic;

namespace NeuralNetworkManager.Services.NeuralNetworks.Contracts.Dtos;

public class GetModelDto
{
    public GetModelDto()
    {

    }

    public GetModelDto(DeepNetBuilder deepNet)
    {
        LearningRate = deepNet.LearningRate;
        Layers = deepNet.Layers;
        Biases = deepNet.Biases;
        HiddenValues = deepNet.HiddenValues;
        Weights = deepNet.Weights.SerializeToJsonArray();
    }

    public double LearningRate { get; set; }

    public int[] Layers { get; set; }

    public double[] Biases { get; set; }

    public List<double[]> HiddenValues { get; set; }

    public List<double[][]> Weights { get; set; }
}