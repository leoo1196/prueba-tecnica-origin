namespace Core.Models;
public class Card
{
    public Card()
    {
        Operations = new HashSet<Operation>();
    }

    public Guid Id { get; set; }
    public string Number { get; set; } = null!;
    public string Pin { get; set; } = null!;
    public bool IsLocked { get; set; }
    public int Attempts { get; set; }
    public decimal Balance { get; set; }
    public DateTime DueDate { get; set; }

    public ICollection<Operation> Operations { get; set; }
}
