namespace Core.Dtos;
public class ExtractionInputDto
{
    public Guid CardId { get; set; }
    public decimal Amount { get; set; }

    public void Deconstruct(out Guid cardId, out decimal amount)
    {
        cardId = CardId;
        amount = Amount;
    }
}
