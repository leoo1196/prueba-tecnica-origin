namespace Core.Models;
public class OperationType
{
    public OperationType()
    {
        Operations = new HashSet<Operation>();
    }

    public int Id { get; set; }
    public string Description { get; set; } = null!;

    public ICollection<Operation> Operations { get; set; }
}
