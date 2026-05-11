namespace PlayersGuide.Level17;

public static class SimulasSoup
{
    public static void Solution()
    {
        string selectedFoodType = PickEnum<FoodType>("food type");
        string selectedMainIngredient = PickEnum<MainIngredient>("main ingredient");
        string selectedSeasoning = PickEnum<Seasoning>("seasoning");

        var soup = (FoodType: selectedFoodType, MainIngredient: selectedMainIngredient, Seasoning: selectedSeasoning);

        Console.WriteLine($"{soup.Seasoning} {soup.MainIngredient} {soup.FoodType}");
    }

    private static string PickEnum<TEnum>(string typeName) where TEnum : struct, Enum
    {
        Console.WriteLine($"Pick a {typeName}:");

        foreach (var enumValue in Enum.GetValues<TEnum>())
        {
            Console.WriteLine($"- {enumValue}");
        }

        return Console.ReadLine()!;
    }
}
