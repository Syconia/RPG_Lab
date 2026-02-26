namespace RPG2App;

public class TopPaddingLayer : PaddingLayer
{
    public TopPaddingLayer(string name, bool isActive, int priority, GameManager gm) : base(name, isActive, priority, gm)
    {
    }

    public override void OnSwitch(GameManager.Context context)
    {
        this.CurrentContext = context;
        switch (this.CurrentContext)
        {
            case GameManager.Context.MainMenu:
                this.LinePadding = 5;
                break;
            case GameManager.Context.CharacterCreation:
                this.LinePadding = 1;
                break;
            case GameManager.Context.Explore:
                this.LinePadding = 1;
                break;
        }
    }
}