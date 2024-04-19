using System;
namespace Contracts.PetDto.Responses
{
	public record GetAllPetsResponse(List<PetDto> PetDtos);
}

