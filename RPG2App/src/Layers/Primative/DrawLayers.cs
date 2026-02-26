namespace RPG2App;

public class DrawLayers
{
    public bool IsActive { get; protected set; }
    public int PriorityTop { get; protected set; }
    protected GameManager GM { get; set; }
    protected GameManager.Context CurrentContext { get; set; }
    public string DebugName;

    public DrawLayers(string name, bool isActive, int priority, GameManager gm)
    {
        this.DebugName = name;
        this.IsActive = isActive;
        this.PriorityTop = priority;
        this.GM = gm;
        this.OnSwitch(gm.CurrentContext);
    }

    public virtual void Draw() {}

    public virtual void OnSwitch(GameManager.Context context)
    {
        this.CurrentContext = context;
    }

    public virtual void ProcessInput(ConsoleKey input) {}
}