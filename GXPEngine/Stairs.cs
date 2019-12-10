using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Stairs:Sprite
    {
        public  Stairs(float x, float y, int width, int height) : base("checkers.png") {
            SetXY(x, y);
            this.width = width;
            this.height = height;
            //SetOrigin(width / 2, height / 2);
            
        }


    }
}
