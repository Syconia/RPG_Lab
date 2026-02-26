namespace RPG2App;

public class PaddingLayer : DrawLayers
{
    public int LinePadding;
    
    public PaddingLayer(string name, bool isActive, int priority, GameManager gm) : base(name, isActive, priority, gm)
    {
    }

    public override void Draw()
    {
        if (!this.IsActive) return;
        string s = "";
        for (int i = 0; i < this.LinePadding; i++) s += "\n";
        Console.WriteLine(s);
    }

    public override void OnSwitch(GameManager.Context context)
    {
        base.OnSwitch(context);
    }
}