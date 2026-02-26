namespace RPG2App;

public class MainScreenLayer : InteractableLayer
{
    public MainScreenLayer(string name, bool isActive, int priority, GameManager gm) : base(name, isActive, priority, gm, false)
    {
        
    }

    public override void Draw()
    {
        if (!this.IsActive) return;
        switch (this.CurrentContext)
        {
            case GameManager.Context.MainMenu:
                Console.WriteLine("  _____  _____   _____   ___  _ ");
                Console.WriteLine(" |  __ \\|  __ \\ / ____| |__ \\| |");
                Console.WriteLine(" | |__) | |__) | |  __     ) | |");
                Console.WriteLine(" |  _  /|  ___/| | |_ |   / /| |");
                Console.WriteLine(" | | \\ \\| |    | |__| |  / /_|_|");
                Console.WriteLine(" |_|  \\_\\_|     \\_____| |____(_)");
                break;
            case GameManager.Context.CharacterCreation:
                Console.WriteLine("Please enter your name:");
                string name = Console.ReadLine()!;
                this.GM.Player.setName(name);
                this.GM.Player.CreateCharacter();
                this.GM.SwitchContext(GameManager.Context.Explore);
                this.GM.FirstRun = false;
                break;
            case GameManager.Context.Explore:
                //This is where the map would go. Just printing some flavour text for now.
                //Also currently changes on each input. Ignore for now
                StaticStrings.PrintExploreFlavourText();
                break;
        }
    }

    public override void OnSwitch(GameManager.Context context)
    {
        this.CurrentContext = context;
        switch (this.CurrentContext)
        {
            case GameManager.Context.MainMenu:
                break;
            case GameManager.Context.CharacterCreation:
                break;
            case GameManager.Context.Explore:
                break;
        }
    }
}