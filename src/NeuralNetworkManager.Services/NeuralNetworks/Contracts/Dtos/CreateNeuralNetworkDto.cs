namespace NeuralNetworkManager.Services.NeuralNetworks.Contracts.Dtos;

public class CreateNeuralNetworkDto
{
    public int[] Layers { get; set; }
    public double LearningRate { get; set; }
}