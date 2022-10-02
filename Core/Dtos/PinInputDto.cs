namespace Core.Dtos;
public class PinInputDto
{
    public string CardNumber { get; set; } = null!;
    public string Pin { get; set; } = null!;

    public void Deconstruct(out string cardNumber, out string pin)
    {
        cardNumber = CardNumber;
        pin = Pin;
    }
}
