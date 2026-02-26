namespace RPG2App;

public class Rat : Enemy
{
    public Rat() : base("Rat", 5, 1, 5, "A small rat.", 10)
    {
        this.FlavourText = "A small rat scurries across your path.";
    }
}