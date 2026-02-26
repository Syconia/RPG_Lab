namespace RPG2App;

public class Player : Entity
{
    public int Experience { get; private set; }
    public int Level { get; private set; }
    public Player() : base()
    {
        this.Experience = 0;
        this.Level = 1;
        this.MaxHealth = 5;
        this.Health = 5;
        this.Strength = 3;
    }

    public Player(string name, int maxHP, int strength) : base(name, maxHP, strength)
    {
        this.Experience = 0;
        this.Level = 1;
    }

    public void setName(string name)
    {
        this.Name = name;
    }

    public void GainExperience(int exp)
    {
        this.Experience += exp;
        if (this.Experience >= 10)
        {
            this.LevelUp();
            this.Experience -= 10;
        }
    }

    public void LevelUp()
    {
        this.Level++;
        this.MaxHealth += 5;
        this.Strength += 2;
        this.Health = this.MaxHealth;
        Console.WriteLine($"Congratulations! You've reached level {this.Level}!");
    }

    //Cheating here
    public void CreateCharacter()
    {
        bool creating = true;
        int HighlightIndex = 0;
        int points = 5;
        string[] statNames = new string[] {"Max Health", "Strength"};
        int[] stats = new int[] {this.MaxHealth, this.Strength};
        while (creating)
        {
            GameManager.Clear();
            Console.WriteLine($"{this.Name}\n\n");
            Console.WriteLine($"Distribute Stats {points} remaining: ");
            for (int i = 0; i < stats.Length; i++)
            {
                if (i == HighlightIndex) 
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{statNames[i]}: {stats[i]}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"{statNames[i]}: {stats[i]}");
                }
            }
            ConsoleKey input = Console.ReadKey().Key;
            switch (input)
            {
                case ConsoleKey.UpArrow:
                    HighlightIndex = Math.Max(0, HighlightIndex - 1);
                    break;
                case ConsoleKey.DownArrow:
                    HighlightIndex = Math.Min(stats.Length - 1, HighlightIndex + 1);
                    break;
                case ConsoleKey.LeftArrow:
                    if (stats[HighlightIndex] > 1)
                    {
                        stats[HighlightIndex]--;
                        points++;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (points > 0)
                    {
                        stats[HighlightIndex]++;
                        points--;
                    }
                    break;
                case ConsoleKey.Enter:
                    GameManager.Clear();
                    Console.WriteLine($"Character Created!\n\nName: {this.Name}\n\nMax Health: {stats[0]}\nStrength: {stats[1]}");
                    Console.WriteLine("Press Enter to confirm or any other key to edit.");
                    input = Console.ReadKey().Key;
                    if (input == ConsoleKey.Enter) creating = false;
                    break;
            }
        }
        GameManager.Clear();
        this.MaxHealth = stats[0];
        this.Health = this.MaxHealth;
        this.Strength = stats[1];
        //This cheating method suppresses input processing so we just prompt user to press any button again. Whoops Late context switch. Fixed?
        //Console.WriteLine("Character creation complete! Press any key to continue.");
    }
}