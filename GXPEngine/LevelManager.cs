using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;
//using GXPEngine.Objects;

public class LevelManager:GameObject
{
    static LevelManager _instance;

    Player _playerInstance;
    public Player PlayerInstace {
        get {
            if (_playerInstance != null)
                return _playerInstance;
            else {
                throw new Exception("Tried to access uninitilized player from Level manager");
            }
        }
        set {
            if (_playerInstance != null)
            {
                if (_playerInstance != value)
                {
                    value.LateDestroy();
                    return;
                }
            }
            else {
                _playerInstance = value;
                AddChild(_playerInstance);
            }
            
        }
    }

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
    public int ActiveLevelIndex {
        set => activeLevelIndex = value;
    }
    List<TiledLevel> levelsList = new List<TiledLevel>();
    Dictionary<string, TiledLevel> levelsDictionary = new Dictionary<string, TiledLevel>();

    public LevelManager() {
        _instance = this;
        LoadLevel("Level1.tmx");
        LoadLevel("Level2.tmx");

        OpenLevel("Level1.tmx");
    }

    public void LoadLevel(string fileName) {
        TiledLevel level = new TiledLevel(fileName);
        levelsList.Add(level);
        levelsDictionary.Add(fileName, level);
    }

    public void DisplayNextLevel(bool right) {
        if (right)
        {
            activeLevelIndex++;
            if (activeLevelIndex >= levelsList.Count)
            {
                activeLevelIndex = 0;
                
            }
        }
        else {
            activeLevelIndex--;
            if (activeLevelIndex < 0) {
                activeLevelIndex = levelsList.Count - 1;
            }
        }
        OpenLevel(activeLevelIndex);
    }
    /// <summary>
    /// Open level by the list index
    /// </summary>
    /// <param name="index"></param>
    public void OpenLevel(int index) {
        foreach (var gameobject in GetChildren()) {
            if(gameobject is TiledLevel)
                gameobject.LateRemove();
        }
        LateAddChildAt(levelsList[index], 0);
    }
    /// <summary>
    /// Open level by the file name
    /// </summary>
    /// <param name="levelName"></param>
    public void OpenLevel(string levelName) {

        //remove previous level
        foreach (var gameobject in GetChildren())
        {
            if (gameobject is TiledLevel)
                gameobject.LateRemove();
        }
            
        //Add as child to level manager the target level
        if (levelsDictionary[levelName] != null)
        {
            LateAddChildAt(levelsDictionary[levelName], 0);
        }
        else {
            Console.WriteLine("Could not find the level with the specified name when calling - LevelManager- OpenLevel(String)");
        }
    }
    



}