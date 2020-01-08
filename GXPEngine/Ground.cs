using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    public class Ground:GameObject
    {
        readonly Sprite hitBox;
        Sprite visuals;


        public Ground(int x, int y, string spritePath){
            this.x = x;
            this.y = y;
            visuals = new Sprite(spritePath, false, false);

            hitBox = new Sprite("playerHitBox.png");
            hitBox.alpha = 0.2f;
            AddChild(visuals);
            AddChild(hitBox);
        }

        public void setSpriteExtent(int width,int height)
        {
            visuals.width = width;
            visuals.height = height;
        }
        public void setHitBoxSize(int width, int height) {
            hitBox.width = width;
            hitBox.height = height;
        }
        public void offsetTheHitBox(int x, int y)
        {
            hitBox.x= x;
            hitBox.y = y;
        }

    }
}
