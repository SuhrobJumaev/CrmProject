namespace Crm.Entities;

public class Order
{
	public int Id { get; set; }
	public string Description { get; set; }
	public decimal Price { get; set; }
	public DateTime OrderDate { get; set; }
	public DeliveryType DeliveryType { get; set; }
	public string DeliveryAddress { get; set; }

}
