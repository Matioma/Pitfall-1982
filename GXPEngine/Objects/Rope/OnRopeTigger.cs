using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    public class OnRopeTigger : Sprite
    {
        public OnRopeTigger (float xOffest, float yOffset) : base("Circle.png") {
            SetOrigin(x + width / 2, y+height);
            x = xOffest;
            y = yOffset;

            alpha = 0;
            //SetScaleXY(0.1f, 0.1f);
        }
    }
}
