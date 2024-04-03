namespace R7P.DeliveryCalculationService.Domain.Entities
{
    public interface IEntity<TId>
    {
        TId Id { get; set; }
    }
}
