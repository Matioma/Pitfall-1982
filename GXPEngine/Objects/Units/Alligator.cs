using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine.Objects.Units
{
    public class Alligator:AnimationSprite
    {
        public Alligator(float x, float y):base("square.png", 1,1)
        {
            SetXY(x, y);
            SetOrigin(width / 2, 0);
        }




    }
}
