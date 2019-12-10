using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine.Units
{
    public class Enemy: Unit
    {
        public Enemy(string path, int cols, int rows, int frames = -1 , bool keepInChache = false , bool addCollider = true): base(path,cols,rows, frames, keepInChache, addCollider) {

        }   


        void Update()
        {
            this.NextFrame();
        }
    }


}
