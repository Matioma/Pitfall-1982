using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;
//using GXPEngine.Objects;

public class LevelManager:GameObject
{
    static LevelManager _instance;

    public static LevelManager Instance {
        get {
            if (_instance != null)
                return _instance;
            else {
                _instance = new LevelManager();
                Console.WriteLine("New Instance was created");
                return _instance;
            }
        }
    }

    int activeLevelIndex = 0;
    List<Level> levelsList = new List<Level>();

    Dictionary<string, Level> levelsDictionary = new Dictionary<string, Level>();

    public LevelManager() {
        /*_instance = this;

        AddLevel("Level1",new Level(LevelType.Level1));
        AddLevel("Level2", new Level(LevelType.Level2));
        OpenLevel("Level1");
        */
        TiledLevel tiled = new TiledLevel();
        AddChild(tiled);
    }

    public void DisplayNextLevel(bool right) {
        Console.WriteLine(activeLevelIndex);
        if (right)
        {
            activeLevelIndex++;
            if (activeLevelIndex >= levelsDictionary.Count)
            {
                activeLevelIndex = 0;
                
            }
            foreach (var levelObject in levelsList[activeLevelIndex].GetChildren()) {
                if (levelObject is Player) {
                    var player = levelObject as Player;
                    //player.x =

                }
            }
        }
        else {
            activeLevelIndex--;
            if (activeLevelIndex < 0) {
                activeLevelIndex = levelsDictionary.Count - 1;
            }
        }
        //OpenLevel(activeLevelIndex);
    }
    public void OpenLevel(int index) {
        //remove previous level
        foreach (var gameobject in GetChildren()) {
            gameobject.LateRemove();
        }
        LateAddChild(levelsList[index]);
        GetChildren()[0].AddChild(Player.PlayerInstance);
    }
    public void OpenLevel(string levelName) {

        //remove previous level
        foreach (var gameobject in GetChildren())
        {
            //LateRemoveChild(gameobject);
            gameobject.LateRemove();
        }
            
        //Add as child to level manager the target level
        if (levelsDictionary[levelName] != null)
        {
            LateAddChild(levelsDictionary[levelName]);
        }
        else {
            Console.WriteLine("Could not find the level with the specified name when calling - LevelManager- OpenLevel(String)");
        }
    }
    private void AddLevel( string name, Level level) {
        levelsDictionary.Add(name, level);
        levelsList.Add(level);
    } 
}