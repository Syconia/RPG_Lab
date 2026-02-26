namespace RPG2App;

class TopBar : DrawLayers
{
    
    public TopBar(string name, bool isActive, int priority, GameManager gm) : base(name, isActive, priority, gm)
    {
        
    }

    public override void Draw()
    {
        if (!this.IsActive) return;
        switch (this.CurrentContext)
        {
            case GameManager.Context.MainMenu:
                break;
            case GameManager.Context.CharacterCreation:
                Console.WriteLine("Character Creation");
                break;
            case GameManager.Context.Explore:
                Console.WriteLine($"The Adventures of {this.GM.Player.Name}!");
                Console.WriteLine("RPG2: Exploration");
                break;
        }
    }

    public override void OnSwitch(GameManager.Context context)
    {
        this.CurrentContext = context;
        switch(this.CurrentContext)
        {
            case GameManager.Context.MainMenu:
                this.IsActive = false;
                break;
            case GameManager.Context.CharacterCreation:
                this.IsActive = true;
                break;
            case GameManager.Context.Explore:
                this.IsActive = true;
                break;
        }
    }
}