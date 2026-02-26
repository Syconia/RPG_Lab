namespace RPG2App;

public static class StaticStrings
{
    public static string[] ExploreFlavourText = ["You feel a gentle breeze.", "Small hopping noises can be heard nearby.",
        "A quiet rustling stirs the silence"];
    
    public static string[] CombatFlavourText = ["You swing your sword at the enemy.", "You strike the enemy with your axe.",
        "You lunge at the enemy with your spear."];

    public static string[] CombatHitText = ["The attack hits!", "Your attack connects!", "You strike true!"];

    public static void PrintExploreFlavourText()
    {
        Random random = new Random();
        int index = random.Next(ExploreFlavourText.Length);
        Console.WriteLine(ExploreFlavourText[index]);
    }
}