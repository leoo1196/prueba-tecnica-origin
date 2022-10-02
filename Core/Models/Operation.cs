namespace Core.Models;
public class Operation
{
    public Guid Id { get; set; }
    public Guid CardId { get; set; }
    public int OperationTypeId { get; set; }
    public DateTime CreatedAt { get; set; }
    public decimal? Amount { get; set; }

    public Card Card { get; set; } = null!;
    public OperationType OperationType { get; set; } = null!;
}
