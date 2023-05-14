using System.Collections.Generic;

namespace NeuralNetworkManager.Services.NeuralNetworks.Contracts.Dtos;

public class UpdateModelDto
{
    public double LearningRate { get; set; }
    public int[] Layers { get; set; }
    public double[] Biases { get; set; }
    public List<double[]> HiddenValues { get; set; }
    public List<double[][]> Weights { get; set; }
}