namespace RPG2App;

public class CombatEncounter : Encounter
{
    public static List<Enemy> Enemies = new List<Enemy>();
    public static int MaxProbability { get; protected set; }
    public Enemy ?CurrentEnemy { get; protected set; }

    public CombatEncounter() : base()
    {
        //For now
        this.Name = "Combat Encounter";
        this.FlavourText = "You encounter an enemy!";
        this.random = new Random();
        this.Type = EncounterType.Combat;
    }

    public CombatEncounter(string name, string flavourText) : base()
    {
        this.Name = name;
        this.FlavourText = flavourText;
        this.random = new Random();
    }

    public void AddEnemy(Enemy enemy)
    {
        Enemies.Add(enemy);
        MaxProbability = (enemy.EncounterProbability > MaxProbability) ? enemy.EncounterProbability : MaxProbability;
    }

    public void RemoveEnemy(Enemy enemy)
    {
        Enemies.Remove(enemy);
        MaxProbability -= enemy.EncounterProbability;
    }

    public Enemy ?GetRandomEnemy()
    {
        //Should work. A bit hacky I think
        int roll = random.Next(0, MaxProbability);
        foreach (Enemy enemy in Enemies.Shuffle())
        {
            if (roll < enemy.EncounterProbability)
            {
                return enemy;
            }
        }
        return null;
    }

    public override void ResolveEncounter()
    {
        this.CurrentEnemy = GetRandomEnemy();
        Console.WriteLine(this.Name);
        this.FlavourText = this.CurrentEnemy!.FlavourText;
        Console.WriteLine(this.FlavourText);
        Console.WriteLine($"You encounter a {this.CurrentEnemy.Name}!");
        //This is where the combat would go. Just printing some flavour text for now.
    }
}