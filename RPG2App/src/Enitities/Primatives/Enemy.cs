namespace RPG2App;

public class Enemy : Entity
{
    public int EncounterProbability { get; protected set; }
    protected int ExperiencePoints;
    public string ?Discription { get; protected set; }

    public string ?FlavourText { get; protected set; }
    public Enemy() : base() {}
    public Enemy(string name, int maxHP, int strength, int expPoints, string description, int encounterProbability) : base(name, maxHP, strength)
    {
        this.ExperiencePoints = expPoints;
        this.Discription = description;
        this.EncounterProbability = encounterProbability;
    }

    public override void Die()
    {
    }

    public int GiveExperience()
    {
        return this.ExperiencePoints;
    }
}