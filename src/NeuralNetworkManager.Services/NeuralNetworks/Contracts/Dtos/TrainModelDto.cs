namespace NeuralNetworkManager.Services.NeuralNetworks.Contracts.Dtos;

public class TrainModelDto
{
    public double[] inputs { get; set; }
    public double[] expectedOutput { get; set; }
}