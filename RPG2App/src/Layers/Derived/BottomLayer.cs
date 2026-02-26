namespace RPG2App;

class BottomLayer : InteractableLayer
{
    
    public BottomLayer(string name, bool isActive, int priority, GameManager gm) : base(name, isActive, priority, gm, true)
    {
        this.ActionList = new List<string>() {"Start Game", "Exit"};
    }

    public override void Draw()
    {
        if (!this.IsActive) return;
        switch (this.CurrentContext)
        {
            case GameManager.Context.MainMenu:
                Console.WriteLine("Welcome to RPG2!");
                this.PrintActions();
                break;
            case GameManager.Context.CharacterCreation:
                break;
            case GameManager.Context.Explore:
                Console.WriteLine ($"{GM.Player.Name}:  Health: {GM.Player.Health}/{GM.Player.MaxHealth}  Strength: {GM.Player.Strength}");
                this.PrintActions();
                break;
        }
    }

    public override void OnSwitch(GameManager.Context context)
    {
        this.CurrentContext = context;
        switch(this.CurrentContext)
        {
            case GameManager.Context.MainMenu:
                this.IsInteractable = true;
                this.ActionList = new List<string>() {"Start Game", "Exit"};
                break;
            case GameManager.Context.CharacterCreation:
                this.IsActive = false;
                this.IsInteractable = false;
                break;
            case GameManager.Context.Explore:
                this.IsActive = true;
                this.IsInteractable = true;
                this.ActionList = new List<string>() {"Explore", "Inventory", "Character Sheet", "Main Menu"};
                break;
        }
    }

    public override void ProcessInput(ConsoleKey input)
    {
        if (!this.IsInteractable) return;
        switch (this.CurrentContext)
        {
            case GameManager.Context.MainMenu:
                switch (input)
                {
                    case ConsoleKey.D1:
                        if (this.GM.FirstRun) this.GM.SwitchContext(GameManager.Context.CharacterCreation);
                        else this.GM.SwitchContext(GameManager.Context.Explore);
                        break;
                    case ConsoleKey.D2:
                        this.GM.IsRunning = false;
                        break;
                }
                this.ProcessArrowInput(input);
                break;
            case GameManager.Context.Explore:
                switch (input)
                {
                    case ConsoleKey.D1:
                        //Unfinished
                        //this.GM.GetEncounter();
                        break;
                    //case ConsoleKey.D2: this.GM.SwitchContext(GameManager.Context.Inventory); break;
                    //case ConsoleKey.D3: this.GM.SwitchContext(GameManager.Context.CharacterScreen); break;
                    case ConsoleKey.D4:
                        this.GM.SwitchContext(GameManager.Context.MainMenu);
                        break;
                }
                this.ProcessArrowInput(input);
                break;
        }
    }

    public override void ProcessAction(int index)
    {
        switch (this.CurrentContext)
        {
            case GameManager.Context.MainMenu:
                if (index == 0)
                {
                    if (this.GM.FirstRun) this.GM.SwitchContext(GameManager.Context.CharacterCreation);
                    else this.GM.SwitchContext(GameManager.Context.Explore);
                }
                else if (index == 1) this.GM.IsRunning = false;
                break;
            case GameManager.Context.Explore:
                switch (index)
                {
                    case 0: this.GM.SwitchContext(GameManager.Context.Explore); break;
                    //case 1: this.GM.SwitchContext(GameManager.Context.Inventory); break;
                    //case 2: this.GM.SwitchContext(GameManager.Context.CharacterScreen); break;
                    case 3: this.GM.SwitchContext(GameManager.Context.MainMenu); break;
                }
                break;
        }
        
    }
}