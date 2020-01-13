using System;									// System contains a lot of default C# libraries 
using System.Drawing;                           // System.Drawing contains a library used for canvas drawing below
using GXPEngine;                                // GXPEngine contains the engine
//using GXPEngine.Objects;
using GXPEngine.Units;

public class MyGame : Game
{
    //readonly Level  levelData;
    LevelManager levelManager;

    public MyGame() : base(800, 600, false)     // Create a window that's 800x600 and NOT fullscreen
    {
        levelManager = new LevelManager();
        //levelData = new Level(LevelType.Level1);
        //AddChild(levelData);

        AddChild(levelManager);

        //GameObject gameObject = new GroundTile();
        //gameObject.SetXY(game.width / 2, game.height / 2);
    }

    void Update()
    {
        
    }



    static void Main()                          // Main() is the first method that's called when the program is run
    {
        new MyGame().Start();                   // Create a "MyGame" and start it

    }
}