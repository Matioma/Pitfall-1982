using GXPEngine.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    public class Level:GameObject
    {
        List<GameObject> LevelSprites = new List<GameObject>();
        public Level() {
            LoadObjects();
            foreach (var SpriteObject in LevelSprites) {
                game.AddChild(SpriteObject);
            }
        }

        void LoadObjects() {
            LevelSprites.Add(new Stairs(game.width / 2, game.height / 2, 100,300));
            LevelSprites.Add(new Player( game.width/2,game.height/2));
            LevelSprites.Add(new Ground(0, Game.main.height - 10, "colors.png"));
            if (LevelSprites.Last() is Ground ground) {
                ground.setSpriteExtent(Game.main.width, 50);
            }
            LevelSprites.Add(new Ground(0, Game.main.height / 2, "colors.png"));
            
            if (LevelSprites.Last() is Ground ground2)
            {
                ground2.setSpriteExtent(Game.main.width / 2, 50);
            }
            
            LevelSprites.Add(new Enemy("barry.png", 7, 1));
        }
    }
}
