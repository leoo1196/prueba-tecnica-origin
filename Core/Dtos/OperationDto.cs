namespace Core.Dtos;
public class OperationDto
{
    public string CardNumber { get; set; } = null!;
    public decimal? ExtractionAmount { get; set; }
    public decimal Balance { get; set; }
    public DateTime OperationTime { get; set; }
}
