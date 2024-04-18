using CSharpFunctionalExtensions;
using PetFamily.Domain.Common;

namespace PetFamily.Domain.ValueObjects;

public record Address
{
    private Address(string city, string street, string building, string index)
    {
        City = city;
        Street = street;
        Building = building;
        Index = index;
    }

    public string City { get; }
    public string Street { get; }
    public string Building { get; }
    public string Index { get; }

    public static Result<Address, Error> Create(string city, string street, string building, string index)
    {
        if (city.IsEmpty())
            return Errors.General.ValueIsRequried(nameof(City));

        if (street.IsEmpty())
            return Errors.General.ValueIsRequried(nameof(Street));

        if (building.IsEmpty())
            return Errors.General.ValueIsRequried(nameof(Building));

        if (index.IsEmpty())
            return Errors.General.ValueIsRequried(nameof(Index));

        return new Address(city, street, building, index);
    }
}