using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine.Units
{
    public class Enemy: Unit
    {
        public Enemy(string path, int cols, int rows): base(path,cols,rows) {

        }
        void Update()
        {
            this.animationSprite.NextFrame();
        }
    }


}
