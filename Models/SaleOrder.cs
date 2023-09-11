public class SaleOrder : Entity
{
    public Customer Customer { get; set; }
    public Seller Seller { get; set; }
    public List<Product> Products { get; set; }
    public DateTime Date { get; set; }
    public double Total { get; set; }
}