namespace RPG2App;

public class GameManager
{
    public enum Context {MainMenu, CharacterCreation, CharacterScreen, Inventory, Explore, Combat};
    public Interaction Interaction { get; private set; }
    public Context CurrentContext { get; private set; }
    public Context PreviousContext { get; private set; }

    public List<DrawLayers> Layers { get; private set; }
    public static int layerCount = 0;
    public bool IsRunning;

    public bool FirstRun { get; set; }

    public Player Player { get; private set; }

    public  GameManager()
    {
        this.Interaction = new Interaction(this);
        //Maybe should delegate to a stack manager class
        this.Layers = new List<DrawLayers>();
        this.CurrentContext = Context.MainMenu;
        this.PreviousContext = this.CurrentContext;
        this.IsRunning = true;
        this.FirstRun = true;
        this.Player = new Player();

        //Register Enemies
        CombatEncounter combatEncounter = new CombatEncounter();
        combatEncounter.AddEnemy(new Rat());
        //Register Encounters
        Encounter.AddEncounter(combatEncounter);
    }

    public void AddLayer(DrawLayers layer)
    {
        this.Layers.Add(layer);
        this.Layers.Sort(SortLayer);
        layerCount++;
    }

    public void SwitchContext(Context next)
    {
        if (this.CurrentContext != this.PreviousContext)
            {
                this.PreviousContext = this.CurrentContext;
            }
        this.CurrentContext = next;
        foreach (DrawLayers layer in this.Layers) layer.OnSwitch(next);
    }

    public void Run()
    {
        while (this.IsRunning)
        {
            Clear();
            this.OnUpdate();
            this.PropogateInput();
        }
    }

    private void OnUpdate()
    {
        foreach (DrawLayers layer in this.Layers) layer.Draw();
    }

    private void PropogateInput()
    {
        ConsoleKey key = this.Interaction.ProcessInputs();
        foreach (DrawLayers layer in this.Layers) layer.ProcessInput(key);
    }

    public void GetEncounter()
    {
        Encounter encounter = Encounter.GetRandomEncounter();
        if (encounter.Type == Encounter.EncounterType.Combat) this.SwitchContext(Context.Combat);
    }

    public static void Clear()
    {
        Console.Clear();
        Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
    }

    private static int SortLayer(DrawLayers x, DrawLayers y)
    {
        if (x == null)
        {
            if (y == null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        else
        {
            if (y == null)
            {
                return -1;
            }
            else
            {
                if (x.PriorityTop < y.PriorityTop)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
        }
    }

    public void DebugWaitKill()
    {
        Console.WriteLine("Await");
        Console.ReadKey(true);
        this.IsRunning = false;
    }
}