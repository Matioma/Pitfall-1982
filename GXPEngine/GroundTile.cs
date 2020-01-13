using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    public class GroundTile:AnimationSprite
    {
        public GroundTile() : base("Tiles.png", 5 ,1) {
            SetFrame(0);
        }
    }
}
