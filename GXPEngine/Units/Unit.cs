using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine.Core;

namespace GXPEngine.Units
{
    
    

    public abstract class Unit : AnimationSprite
    {
        public bool IsOnGround {
            get {
                return CheckIfOnGround();
            }
        }
        
        private float animationTime = 0.0f;

        public Unit(string path, int cols, int rows, int frames = -1, bool keepInChache = false, bool addCollider = true) :
                                                                        base(path, cols, rows, frames, keepInChache, addCollider)
        {
            SetOrigin(width/2, height);
            SetXY(game.width / 2, game.height / 2);
        }
        public virtual void Update()
        {
        }

        bool CheckIfOnGround() {
            foreach (GameObject collidedObject in GetCollisions()) {
                if (collidedObject is Ground) {
                        return true;
                }
            }
            return false;
        }
        protected void HandleAnimation(float frameTime, int startFrame, int numberOfFrames)
        {
            animationTime += Time.deltaTime;
            SetFrame((int)(animationTime / frameTime) % numberOfFrames + startFrame);
        }
    }
}
