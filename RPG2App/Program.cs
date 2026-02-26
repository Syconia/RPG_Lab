using System.Dynamic;

namespace RPG2App;

class Program
{
    static void Main(string[] args)
    {
        GameManager GM = new GameManager();
        GM.AddLayer(new TopBar("top bar", true, -1, GM));
        GM.AddLayer(new TopPaddingLayer("top padding", true, 0, GM));
        GM.AddLayer(new MainScreenLayer("main screen", true, 1, GM));
        GM.AddLayer(new MidPaddingLayer("mid padding", true, 2, GM));
        GM.AddLayer(new BottomLayer("bottom layer", true, 3, GM));
        GM.Run();
    }
}
