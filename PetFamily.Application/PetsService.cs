﻿using Contracts.Requests;
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
            request.Color,
            address.Value,
            place.Value,
            weight.Value,
            false,
            "fsdfsdf",
            contactPhoneNumber.Value,
            volunteerPhoneNumber.Value,
            true);

        var idResult = await _petsRepository.Add(pet.Value, ct);
        if (idResult.IsFailure)
            return idResult.Error;
        
        return idResult;
    }
}