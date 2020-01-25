using System;                                   // System contains a lot of default C# libraries 
using System.Collections.Generic;
using System.Drawing;                           // System.Drawing contains a library used for canvas drawing below
using GXPEngine;                                // GXPEngine contains the engine
//using GXPEngine.Objects;
using GXPEngine.Units;

public class MyGame : Game
{
    public static MyGame Instance;

    LevelManager levelManager;
    public Dictionary<string, Sound> sounds = new Dictionary<string, Sound>();

    public MyGame() : base(800, 600, false)     // Create a window that's 800x600 and NOT fullscreen
    {
        Instance = this;
        levelManager = new LevelManager();
        AddChild(levelManager);
        LoadSounds();
    }

    void Update()
    {
        
    }


    static void Main()                          // Main() is the first method that's called when the program is run
    {
        new MyGame().Start();                   // Create a "MyGame" and start it
    }

    void LoadSounds() {
        Sound sound = new Sound("Mellow_Hipster.mp3",true);
        sound.Play();
        sounds.Add("Background", sound);


        sound = new Sound("Death.mp3", false);
        sounds.Add("Death", sound);

        sound = new Sound("Damage.wav", false);
        sounds.Add("Damage", sound);
    }
}