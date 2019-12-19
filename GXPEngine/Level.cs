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
            LevelSprites.Add(new Player( game.width/4,game.height/3));
            LevelSprites.Add(new Ground(0, Game.main.height - 10, "colors.png"));
            if (LevelSprites.Last() is Ground ground) {
                ground.setSpriteExtent(Game.main.width, 50);
            }
            LevelSprites.Add(new Ground(0, Game.main.height / 2, "colors.png"));
            if (LevelSprites.Last() is Ground ground2)
            {
                ground2.setSpriteExtent(Game.main.width / 2, 50);
            }
            LevelSprites.Add(new Ground(game.width / 2+50, Game.main.height / 2, "colors.png"));
            if (LevelSprites.Last() is Ground ground3)
            {
                ground3.setSpriteExtent(Game.main.width / 2, 50);
            }

            LevelSprites.Add(new BoxEnemy(Game.main.width/2  + 150,Game.main.height/2));
            LevelSprites.Add(new Rope(120,0));
        }
    }
}
