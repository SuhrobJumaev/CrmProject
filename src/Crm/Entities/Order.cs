namespace Crm.Entities;

public class Order
{
    private string? _description;
    private decimal _price;
    private DateTime? _orderDate;
    private DeliveryType? _deliveryType;
    private string? _deliveryAddress;

    public int Id { get; set; }

    public required string Description
    {
        get => _description ?? string.Empty;
        init => _description = value is { Length: > 0 } ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public required decimal Price
    {
        get => _price;
        init => _price = value > 0 ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public required DateTime? OrderDate
    {
        get => _orderDate ?? null;
        init => _orderDate = value is not null ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public required DeliveryType? DeliveryType
    {
        get => _deliveryType ?? null;
        init => _deliveryType = value is not null ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public required string? DeliveryAddress
    {
        get => _deliveryAddress ?? string.Empty;
        init => _deliveryAddress = value is { Length: > 0 } ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }
}
