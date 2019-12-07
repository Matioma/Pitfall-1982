using System;									// System contains a lot of default C# libraries 
using System.Drawing;                           // System.Drawing contains a library used for canvas drawing below
using GXPEngine;								// GXPEngine contains the engine


public class MyGame : Game
{
    Player player;
    Ground ground;


    public MyGame() : base(800, 600, false)		// Create a window that's 800x600 and NOT fullscreen
	{
        Console.WriteLine(ground);
        player = new Player(120,200,"triangle.png");

        ground = new Ground(0, Game.main.height - 10, "colors.png");
        ground.setSpriteExtent(Game.main.width, 50);
        AddChild(player);
        AddChild(ground);
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