using Contracts.PetDto.Responses;
using Contracts.Requests;
using CSharpFunctionalExtensions;
using PetFamily.Application.Abstractions;
using PetFamily.Domain.Common;
using PetFamily.Domain.Entities;
using PetFamily.Domain.ValueObjects;

namespace PetFamily.Application;

public class PetsService
{
    private readonly IPetsRepository _petsRepository;

    public PetsService(IPetsRepository petsRepository)
    {
        _petsRepository = petsRepository;
    }

    public async Task<Result<Guid, Error>> CreatePet(CreatePetRequest request, CancellationToken ct)
    {
        var address = Address.Create(request.City, request.Street, request.Building, request.Index);
        if (address.IsFailure)
            return address.Error;

        var place = Place.Create(request.Place);
        if (place.IsFailure)
            return place.Error;

        var weight = Weight.Create(request.Weight);
        if (weight.IsFailure)
            return weight.Error;

        var contactPhoneNumber = PhoneNumber.Create(request.ContactPhoneNumber);
        if (contactPhoneNumber.IsFailure)
            return contactPhoneNumber.Error;

        var volunteerPhoneNumber = PhoneNumber.Create(request.VolunteerPhoneNumber);
        if (volunteerPhoneNumber.IsFailure)
            return volunteerPhoneNumber.Error;

        var pet = Pet.Create(
            request.Nickname,
            request.Description,
            request.Breed,
            request.Color,
            request.PeopleAttitude,
            request.AnimalAttitude,
            request.Health,
            request.Height,
            request.BirthDate,
            address.Value,
            place.Value,
            weight.Value,
            contactPhoneNumber.Value,
            volunteerPhoneNumber.Value,
            request.OnTreatment,
            request.OnlyOneInFamily,
            request.Castration);


        var idResult = await _petsRepository.Add(pet.Value, ct);

        if (idResult.IsFailure)
            return idResult.Error;
        
        return idResult;
    }
    public async Task<List<GetAllPetsResponse>> GetAll(CancellationToken ct)
    {
        var petsList = await _petsRepository.GetAll(ct);
        List<GetAllPetsResponse> response = new List<GetAllPetsResponse>();
        petsList.ForEach(x =>
        {
            response.Add(new GetAllPetsResponse(
                x.Id,
                x.Nickname,
                x.Color,
                x.Description,
                x.Breed,
                x.Health,
                x.Address.City,
                x.Address.Street,
                x.Address.Building,
                x.Address.Index,
                x.Place.Value,
                x.Weight.Kilograms,
                x.BirthDate,
                x.OnlyOneInFamily,
                Convert.ToInt32(x.Height),
                x.ContactPhoneNumber.Number,
                x.VolunteerPhoneNumber.Number,
                x.PeopleAttitude,
                x.AnimalAttitude,
                x.OnTreatment,
                x.Castration
                ));
        });
        return response;
    }
}