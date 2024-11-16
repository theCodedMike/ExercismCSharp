using System;
using System.Linq;

public enum Allergen
{
    Eggs = 1,
    Peanuts = 2,
    Shellfish = 4,
    Strawberries = 8,
    Tomatoes = 16,
    Chocolate = 32,
    Pollen = 64,
    Cats = 128,
}

public class Allergies
{
    private readonly int _score;
    private static readonly Allergen[] Allergens =
    [
        Allergen.Eggs,
        Allergen.Peanuts,
        Allergen.Shellfish,
        Allergen.Strawberries,
        Allergen.Tomatoes,
        Allergen.Chocolate,
        Allergen.Pollen,
        Allergen.Cats,
    ];

    public Allergies(int mask) => _score = mask;
    public bool IsAllergicTo(Allergen allergen) => (_score & (int)allergen) != 0;
    public Allergen[] List() => Allergens.Where(item => ((int)item & _score) != 0).ToArray();
}