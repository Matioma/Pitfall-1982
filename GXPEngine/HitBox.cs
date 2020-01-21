using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    public class HitBox:Sprite
    {
        public HitBox() : base("playerHitBox.png") {
            alpha = 0f;
            SetOrigin(0,0);
            SetXY(0, 10);
        }
    }
}
