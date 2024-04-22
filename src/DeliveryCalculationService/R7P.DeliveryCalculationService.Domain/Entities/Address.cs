﻿namespace R7P.DeliveryCalculationService.Domain.Entities;

public class Address : IEntity<long>
{
    public long Id { get; set; }

    public required string AddressInfo { get; set; }

    //public required string Name { get; set; }

    //public required string Email { get; set; }

    //public required string PhoneNumber { get; set; }
}