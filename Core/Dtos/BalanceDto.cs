namespace Core.Dtos;
public class BalanceDto
{
    public string CardNumber { get; set; } = null!;
    public decimal Balance { get; set; }
    public DateTime DueDate { get; set; }
}
