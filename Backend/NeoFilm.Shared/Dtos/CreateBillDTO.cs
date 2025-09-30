public class CreateBillDTO
{
    public DateTime Date { get; set; }
    public decimal Total { get; set; }
    public int UserId { get; set; }
    public int PaymentId { get; set; }
}