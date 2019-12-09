using System;									// System contains a lot of default C# libraries 
using System.Drawing;                           // System.Drawing contains a library used for canvas drawing below
using GXPEngine;								// GXPEngine contains the engine

using GXPEngine.Units;

public class MyGame : Game
{
    Player player;
    Ground ground;
    Ground ground1;
    Enemy enemy;
    Level levelData;


    public MyGame() : base(800, 600, false)		// Create a window that's 800x600 and NOT fullscreen
	{
        levelData = new Level();
        /*Console.WriteLine(ground);
        player = new Player(120, 200, "triangle.png");
        AddChild(player);

        ground = new Ground(0, Game.main.height - 10, "colors.png");
        ground.setSpriteExtent(Game.main.width, 50);

        AddChild(ground);
        ground1 = new Ground(0, Game.main.height / 2, "colors.png");
        ground1.setSpriteExtent(Game.main.width / 2, 50);
        AddChild(ground1);

        enemy = new Enemy("barry.png", 7, 1, 7`);
        AddChild(enemy);*/
    }

    void Update()
	{
        //GetGameObjectCollisions(ground);
		// Empty
	}

	static void Main()							// Main() is the first method that's called when the program is run
	{
		new MyGame().Start();					// Create a "MyGame" and start it
    
	}
}