using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Stairs:AnimationSprite
    {
        /*public  Stairs(float x, float y, int width, int height) : base("ledder.png") {
            SetXY(x, y);
            this.width = width;
            this.height = height;
            //SetScaleXY(3,3);
            //SetOrigin(width / 2, height / 2);
            
        }*/

        public Stairs() : base("Tiles.png", 5, 1)
        {
            //SetXY(x, y);
            SetFrame(1);
            //this.width = width;
            //this.height = height;
            //SetScaleXY(3,3);
            //SetOrigin(width / 2, height / 2);

        }

        public Stairs(int x, int y) : base("Tiles.png", 5, 1)
        {
            SetXY(x, y);
            SetFrame(1);
            //this.width = width;
            //this.height = height;
            //SetScaleXY(3,3);
            //SetOrigin(width / 2, height / 2);

        }


    }
}
