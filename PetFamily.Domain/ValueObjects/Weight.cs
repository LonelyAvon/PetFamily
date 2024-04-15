namespace PetFamily.Domain.ValueObjects;

public record Weight
{
    public int Grams { get; set; }

    public Weight(float weight)
    {
        Grams = Convert.ToInt32(weight) * 1000;
    }
}