namespace RPG2App;

public class InteractableLayer : DrawLayers
{
    protected bool IsInteractable;
    protected bool Highlighted;
    protected int HighlightIndex;
    protected List<string> ActionList;
    protected static ConsoleKey[] ActivateKeys = [ConsoleKey.LeftArrow, ConsoleKey.RightArrow, ConsoleKey.UpArrow, ConsoleKey.DownArrow, ConsoleKey.Enter];
    public InteractableLayer(string name, bool isActive, int priority, GameManager gm, bool isInteractable) : base(name, isActive, priority, gm)
    {
        this.IsInteractable = isInteractable;
        this.Highlighted = false;
        this.HighlightIndex = 0;
        this.ActionList = new List<string>();
    }

    protected void ResetHighlight()
    {
        this.Highlighted = false;
        this.HighlightIndex = 0;
    }

    protected void PrintActions()
    {
        for (int i = 0; i < this.ActionList.Count; i++)
        {
            if (this.Highlighted && i == this.HighlightIndex) 
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write($"{i+1}: {this.ActionList[i]}");
                Console.ResetColor();
            }
            else Console.Write($"{i+1}: {this.ActionList[i]}");
            Console.Write("\t\t");
        }
    }

    public virtual void ProcessArrowInput(ConsoleKey input)
    {
        if (IsInteractable)
        {
            if (!Highlighted && ActivateKeys.Contains(input))
            {
                this.Highlighted = true;
            }
            else
            {
                switch (input)
                {
                    case ConsoleKey.LeftArrow:
                        this.HighlightIndex = Math.Max(0, this.HighlightIndex - 1);
                        break;
                    case ConsoleKey.RightArrow:
                        this.HighlightIndex = Math.Min(this.ActionList.Count - 1, this.HighlightIndex + 1);
                        break;
                    case ConsoleKey.Enter:
                        this.ProcessAction(this.HighlightIndex);
                        break;
                }
            }
        }
    }

    public virtual void ProcessAction(int index)
    {}
}