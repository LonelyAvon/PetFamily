using System;
namespace Contracts.PetDto.Responses
{
    public record PetDto(
            Guid Id,
            string Nickname,
            string Color,
            string Description,
            string Breed,
            string Health,
            string City,
            string Street,
            string Building,
            string Index,
            string Place,
            float Weight,
            DateTimeOffset BirthDate,
            bool OnlyOneInFamily,
            int Height,
            string ContactPhoneNumber,
            string VolunteerPhoneNumber,
            string PeopleAttitude,
            string AnimalAttitude,
            bool OnTreatment,
            bool Castration);
}

