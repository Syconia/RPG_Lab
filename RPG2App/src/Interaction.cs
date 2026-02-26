namespace RPG2App;

public class Interaction
{
    private GameManager GM;
    public bool AwaitKey { get; set; }
    public Interaction(GameManager gm)
    {
        this.GM = gm;
        this.AwaitKey = true;
    }

    public ConsoleKey ProcessInputs()
    {
        return Console.ReadKey(true).Key;
    }
}