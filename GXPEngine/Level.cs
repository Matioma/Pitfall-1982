using GXPEngine.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    public class Level:GameObject
    {
        readonly List<GameObject> LevelSprites = new List<GameObject>();
        public Level() {
            LoadObjects();
            foreach (var SpriteObject in LevelSprites) {
                AddChild(SpriteObject);
            }
        }

        void LoadObjects() {
            LevelSprites.Add(new Stairs(game.width / 2, game.height / 2, 50,300));
            
            LevelSprites.Add(new Ground(0, Game.main.height - 10, "Ground_Low.png"));
            if (LevelSprites.Last() is Ground ground) {
                ground.setSpriteExtent(Game.main.width, 50);
                ground.setHitBoxSize(Game.main.width, 25);
                ground.offsetTheHitBox(0, 0);
            }
            LevelSprites.Add(new Ground(0, Game.main.height / 2, "Ground_Low.png"));
            if (LevelSprites.Last() is Ground ground2)
            {
                ground2.setSpriteExtent(Game.main.width / 2, 50);
                ground2.setHitBoxSize(Game.main.width / 2, 50);
                ground2.offsetTheHitBox(0, 10);
            }
            LevelSprites.Add(new Ground(game.width / 2+50, Game.main.height / 2, "Ground_Low.png"));
            if (LevelSprites.Last() is Ground ground3)
            {
                ground3.setSpriteExtent(Game.main.width / 2, 50);
                ground3.setHitBoxSize(Game.main.width / 2, 50);
                ground3.offsetTheHitBox(0, 10);
            }

            LevelSprites.Add(new BoxEnemy(Game.main.width/2  + 150,Game.main.height/2));
            LevelSprites.Add(new Rope(120,0));

            LevelSprites.Add(new Player(game.width / 4, game.height / 4));
        }
    }
    public class LevelManager
    {
       
    }
}
