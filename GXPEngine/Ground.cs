using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    public class Ground:Sprite
    {
        public Ground(int x, int y, string spritePath):base(spritePath) {
            this.x = x;
            this.y = y;
        }

        public void setSpriteExtent(int width,int height)
        {
            this.width = width;
            this.height = height; 
        }

    }
}
