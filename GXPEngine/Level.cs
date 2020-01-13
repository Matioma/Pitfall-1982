using GXPEngine.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    public enum LevelType {
        Level1,
        Level2,
        Level3,
    }
    public class Level : GameObject
    {
        /*List<GameObject> _levelGameObjects = new List<GameObject>();

        //private static Player _player;
        

        public Level() {
            //InitializePlayer();
            TestLevel();
            foreach (var SpriteObject in _levelGameObjects) {
                AddChild(SpriteObject);
            }
            AddPlayer();
           
        }
        public Level(LevelType levelType)
        {
            //InitializePlayer();
            AddPlayer();
            switch (levelType) {
                case LevelType.Level1:
                    SetupLevel1();
                    break;
                case LevelType.Level2:
                    SetupLevel2();
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
            foreach (var SpriteObject in _levelGameObjects)
            {
                AddChild(SpriteObject);
            }
        }

        void AddPlayer() {
            Player player = new Player(game.width / 4, game.height / 4);
        }

        void SetupLevel1()
        {
            _levelGameObjects.Add(new Stairs(game.width / 2, game.height / 2 + 30, 50, 300));

            _levelGameObjects.Add(new Ground(0, Game.main.height - 10, "Ground_Low.png"));
            if (_levelGameObjects.Last() is Ground ground)
            {
                ground.SetSpriteExtent(Game.main.width, 50);
                ground.SetHitBoxSize(Game.main.width, 25);
                ground.OffsetTheHitBox(0, 0);
            }
            _levelGameObjects.Add(new Ground(0, Game.main.height / 2, "Ground_Top.png"));
            if (_levelGameObjects.Last() is Ground ground2)
            {
                ground2.SetSpriteExtent(Game.main.width / 2, 70);
                ground2.SetHitBoxSize(Game.main.width / 2, 40);
                ground2.OffsetTheHitBox(0, 20);
            }
            _levelGameObjects.Add(new Ground(game.width / 2 + 50, Game.main.height / 2, "Ground_Top.png"));
            if (_levelGameObjects.Last() is Ground ground3)
            {
                ground3.SetSpriteExtent(Game.main.width / 2, 70);
                ground3.SetHitBoxSize(Game.main.width / 2, 40);
                ground3.OffsetTheHitBox(0, 20);
            }

            _levelGameObjects.Add(new BoxEnemy(Game.main.width / 2 + 150, Game.main.height / 2));

           
            _levelGameObjects.Add(new Player(game.width / 4, game.height / 4));
        }
        void SetupLevel2()
        {
            _levelGameObjects.Add(new Ground(0, Game.main.height - 10, "Ground_Low.png"));
            if (_levelGameObjects.Last() is Ground ground)
            {
                ground.SetSpriteExtent(Game.main.width, 50);
                ground.SetHitBoxSize(Game.main.width, 25);
                ground.OffsetTheHitBox(0, 0);
            }
            _levelGameObjects.Add(new Ground(0, Game.main.height / 2, "Ground_Top.png"));
            if (_levelGameObjects.Last() is Ground ground2)
            {
                ground2.SetSpriteExtent(Game.main.width / 2, 70);
                ground2.SetHitBoxSize(Game.main.width / 2, 40);
                ground2.OffsetTheHitBox(0, 20);
            }
            _levelGameObjects.Add(new Ground(game.width / 2 + 50, Game.main.height / 2, "Ground_Top.png"));
            if (_levelGameObjects.Last() is Ground ground3)
            {
                ground3.SetSpriteExtent(Game.main.width / 2, 70);
                ground3.SetHitBoxSize(Game.main.width / 2, 40);
                ground3.OffsetTheHitBox(0, 20);
            }

            _levelGameObjects.Add(new BoxEnemy(Game.main.width / 2 + 150, Game.main.height / 2));
            _levelGameObjects.Add(new Player(game.width / 4, game.height / 4));

           

        }
        void TestLevel() {
            _levelGameObjects.Add(new Stairs(game.width / 2, game.height / 2+30, 50,300));
            
            _levelGameObjects.Add(new Ground(0, Game.main.height - 10, "Ground_Low.png"));
            if (_levelGameObjects.Last() is Ground ground) {
                ground.SetSpriteExtent(Game.main.width, 50);
                ground.SetHitBoxSize(Game.main.width, 25);
                ground.OffsetTheHitBox(0, 0);
            }
            _levelGameObjects.Add(new Ground(0, Game.main.height / 2, "Ground_Top.png"));
            if (_levelGameObjects.Last() is Ground ground2)
            {
                ground2.SetSpriteExtent(Game.main.width / 2, 70);
                ground2.SetHitBoxSize(Game.main.width / 2, 40);
                ground2.OffsetTheHitBox(0, 20);
            }
            _levelGameObjects.Add(new Ground(game.width / 2+50, Game.main.height / 2, "Ground_Top.png"));
            if (_levelGameObjects.Last() is Ground ground3)
            {
                ground3.SetSpriteExtent(Game.main.width / 2, 70);
                ground3.SetHitBoxSize(Game.main.width / 2, 40);
                ground3.OffsetTheHitBox(0, 20);
            }

            _levelGameObjects.Add(new BoxEnemy(Game.main.width/2  + 150,Game.main.height/2));
            _levelGameObjects.Add(new Rope(120,0));

            //var player = new Player(game.width / 4, game.height / 4);
            _levelGameObjects.Add(Player.PlayerInstance);
        }*/
    }

}
