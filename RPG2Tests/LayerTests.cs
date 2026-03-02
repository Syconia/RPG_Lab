using RPG2App;

namespace RPG2Tests;

public class LayerTests
{
    [Fact]
    public void Layer_CreationTest()
    {
        GameManager GM = new GameManager();
        BottomLayer bottomLayer = new BottomLayer("bottom layer", true, 3, GM);
        Assert.Equal("bottom layer", bottomLayer.DebugName);
        Assert.True(bottomLayer.IsActive);
    }

    [Fact]
    public void Layer_SwitchContextTest()
    {
        GameManager GM = new GameManager();
        BottomLayer bottomLayer = new BottomLayer("bottom layer", true, -1, GM);
        GM.AddLayer(bottomLayer);
        Assert.True(bottomLayer.IsInteractable);
        GM.SwitchContext(GameManager.Context.CharacterCreation);
        Assert.False(bottomLayer.IsInteractable);
    }

    [Fact]
    public void Layer_ProcessInputTest()
    {
        GameManager GM = new GameManager();
        BottomLayer bottomLayer = new BottomLayer("bottom layer", true, -1, GM);
        GM.AddLayer(bottomLayer);
        Assert.Equal(GameManager.Context.MainMenu, GM.CurrentContext);
        bottomLayer.ProcessInput(ConsoleKey.D1);
        Assert.Equal(GameManager.Context.CharacterCreation, GM.CurrentContext);
    }

    [Fact]
    public void Layer_PriorityTest()
    {
        GameManager GM = new GameManager();
        TopBar topBar = new TopBar("top bar", true, -1, GM);
        BottomLayer bottomLayer = new BottomLayer("bottom layer", true, 3, GM);
        PaddingLayer paddingLayer = new PaddingLayer("padding layer", true, 0, GM);
        GM.AddLayer(bottomLayer);
        GM.AddLayer(topBar);
        GM.AddLayer(paddingLayer);
        Assert.Equal("top bar", GM.Layers[0].DebugName);
        Assert.Equal("padding layer", GM.Layers[1].DebugName);
        Assert.Equal("bottom layer", GM.Layers[2].DebugName);
    }
}
